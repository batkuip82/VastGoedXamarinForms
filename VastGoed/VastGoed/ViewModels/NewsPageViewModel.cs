using System;
using Prism.Navigation;
using System.Net.Http;
using System.Xml.Linq;
using HtmlAgilityPack;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using Prism.Commands;
using Xamarin.Forms;

namespace VastGoed.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {

        private string _url;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _articleHtml = "";
        public string ArticleHtml
        {
            get { return _articleHtml; }
            set { SetProperty(ref _articleHtml, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }


        public DelegateCommand Share { get; private set; }

        public NewsPageViewModel()
        {
            Share = new DelegateCommand(ShareCommand);
        }

        private void ShareCommand()
        {
            MessagingCenter.Send<string>(this._url, "Share");
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Title = System.Net.WebUtility.UrlDecode((string)parameters["title"]);
            Category = (string)parameters["category"];

            _url = (string)parameters["url"];
            SetContent();
        }

        private void SetContent()
        {
            IsBusy = true;
            FetchArticleHtmlFromUrl(_url).ContinueWith((t) =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Task.Delay(3000).ContinueWith(z =>
                   {
                       ArticleHtml = t.Result;
                       IsBusy = false;
                   });
                }
            });

        }

        private async Task<string> FileGetAsync(string file)
        {
            var assembly = typeof(Views.NewsListPageView).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(file);
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = await reader.ReadToEndAsync();
            }

            return text;
        }


        private async Task<string> FetchArticleHtmlFromUrl(string url)
        {
            //var client = new HttpClient();
            //var response = await client.GetStringAsync(_url);
            var response = await FileGetAsync("VastGoed.ViewModels.testnewsitem.txt");
            var style = await FileGetAsync("VastGoed.ViewModels.style.txt");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response);
            var articleNode = doc.DocumentNode
                .Descendants("div").Where(div => div.GetAttributeValue("itemprop", "") == "articleBody");


            var html = new StringBuilder();

            //                    < style >
            //            body { background - color: white; }
            //p    { color: black; font - size:11px}
            //        </ style >


            html.Append("<html>");
            //html.Append(
            //    @"<head> 
            //        <link rel='stylesheet' id='smartmag-core-css'  href='http://vastgoedberichten.nl/wp-content/themes/smart-mag/style.css?ver=2.3.0' type='text/css' media='all' />
            //    </head>");
            html.Append(
                $@"<head>
                    <style>{style}</style> 
                </head>");
            html.Append("<body>");
            html.Append(articleNode.FirstOrDefault().InnerHtml);
            html.Append("</body></html>");

            return html.ToString();
        }
    }
}
