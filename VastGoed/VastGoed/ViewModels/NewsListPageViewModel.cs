using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using VastGoed.Helpers;
using VastGoed.Models;
using Xamarin.Forms;

namespace VastGoed.ViewModels
{
    public class NewsListPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        private int _id = -1;
        private string _feedUrl = "";

        private ObservableCollection<Item> _feedItems;
        public ObservableCollection<Item> FeedItems
        {
            get { return _feedItems; }
            set { SetProperty(ref _feedItems, value); }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private Item _selectedNewsItem;
        public Item SelectedNewsItem
        {
            get { return _selectedNewsItem; }
            set { SetProperty(ref _selectedNewsItem, value); }
        }

        public DelegateCommand ItemTappedCommand { get; private set; }


        public NewsListPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ItemTappedCommand = new DelegateCommand(navigateToNewsPage);
        }

        private void navigateToNewsPage()
        {
            var item = SelectedNewsItem;
            _navigationService.NavigateAsync(System.Net.WebUtility.UrlEncode($"NewsPage?title={item.Title}&category={item.Category}&url={item.Link2}"));
        }

        private async Task<ObservableCollection<Item>> setListView()
        {
            //var xmlResult = await httpClientGetAsync(_feedUrl);
            var xmlResult = await FileGetAsync();
            var parsedXml = ParseXMLHelpers.ParseXML<Rss>(xmlResult);
            return new ObservableCollection<Item>(parsedXml.Channel.Item);
        }

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        private async Task<string> httpClientGetAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_feedUrl);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        private async Task<string> FileGetAsync()
        {
            var assembly = typeof(Views.NewsListPageView).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("VastGoed.ViewModels.testfeed.txt");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }

        public void GetNewsFeeds(int id)
        {
            switch (id)
            {
                case 0:
                    _feedUrl = "http://www.vastgoedberichten.nl/feed/";
                    PageTitle = "Home";
                    break;
                case 1:
                    _feedUrl = "http://vastgoedberichten.nl/category/nieuws/feed";
                    PageTitle = "Nieuws";
                    break;
                default:
                    break;
            }

            IsBusy = true;

            var x = setListView().ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    //Debug.WriteLine("Found {0} Titles.", t.Result.Count);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Task.Delay(1500).ContinueWith(z =>
                        {
                            FeedItems = t.Result;
                            IsBusy = false;
                        });
                        
                    });
                };
            });


        }

        private string ConvertLinkUrlToImageSource(string linkUrl)
        {
            var imageSource = "";
            var uri = new Uri(linkUrl);
            var imagePath = uri.AbsolutePath.Split('/').Last();



            return imageSource;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("id"))
            {
                _id = int.Parse(parameters["id"].ToString());
                GetNewsFeeds(_id);
            }
        }
    }
}
