using System;
using Prism.Unity;

using Xamarin.Forms;
using VastGoed.Views;
using VastGoed.ViewModels;

namespace VastGoed
{
    public static class ViewModelLocator
    {

        static NewsPageViewModel newsPageVM;
        public static NewsPageViewModel NewsListPageViewModel => 
            newsPageVM ?? (newsPageVM = new NewsPageViewModel());
    }

    public class App : PrismApplication //Application
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MasterPageView/NewsNavigationPageView/NewsListPageView?id=0", animated: false);
        }


        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPageView, MainPageViewModel>();
            Container.RegisterTypeForNavigation<MasterPageView, MasterPageViewModel>();
            Container.RegisterTypeForNavigation<NewsNavigationPageView, NewsNavigationPageViewModel>();
            Container.RegisterTypeForNavigation<NewsListPageView, NewsListPageViewModel>();
            Container.RegisterTypeForNavigation<NewsPage, NewsPageViewModel>();
            Container.RegisterTypeForNavigation<ListViewAnimationPage>();
        }

    }
}
