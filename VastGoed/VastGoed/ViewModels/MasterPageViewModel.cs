using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using VastGoed.Models;
using Xamarin.Forms;
using System;

namespace VastGoed.ViewModels
{
    //public partial class MasterDetailRootPage : MasterDetailPage
    //{
    //    public static readonly BindableProperty CurrentPageProperty =
    //        //BindableProperty.Create<MasterDetailRootPage, Page>(x => x.CurrentPage, 
    //        //    null, BindingMode.TwoWay, propertyChanged: OnItemsSourcePropertyChanged);
    //        BindableProperty.Create(nameof(CurrentPage), typeof(Page), typeof(MasterDetailPage), 
    //            propertyChanged:OnItemsSourcePropertyChanged);

    //    public MasterDetailRootPage()
    //    {
    //        InitializeComponent();
    //    }

    //    public Page CurrentPage { get; set; }

    //    private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    //    {
    //        var masterDetailPage = (MasterDetailRootPage)bindable;
    //        masterDetailPage.Detail = newValue as Page;
    //    }
    //}

    //https://github.com/PrismLibrary/Prism/tree/master/Sandbox/Xamarin/HelloWorld/HelloWorld/HelloWorld/Views

    public class MasterPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;
         
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MasterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string name)
        {
            _navigationService.NavigateAsync(name);              
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
