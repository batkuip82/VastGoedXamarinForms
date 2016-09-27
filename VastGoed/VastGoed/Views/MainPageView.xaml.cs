using System;
using VastGoed.Models;
using Xamarin.Forms;

namespace VastGoed.Views
{
    public partial class MainPageView : ContentPage
    {

        public MainPageView()
        {
            InitializeComponent();
            //masterPage.ListView.ItemSelected += OnItemSelected;
        }


        void Button_Clicked(object sender, EventArgs e)
        {

        }

        //void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MasterPageItem;
        //    if (item != null)
        //    {
        //        object[] array = new[] { (object)item.Id };
        //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, array));
        //        masterPage.ListView.SelectedItem = null;
        //        IsPresented = false;
        //    }
        //}
    }
}
