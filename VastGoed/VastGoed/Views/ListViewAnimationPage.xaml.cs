using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VastGoed.Views
{
    public partial class ListViewAnimationPage : ContentPage
    {
        //TODO: Create custom cell (https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/customizing-cell-appearance/)


        ObservableCollection<int> _items;
        ObservableCollection<int> Items
        {
            get
            {
                if (_items == null)
                    _items = new ObservableCollection<int>();

                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public ListViewAnimationPage()
        {
            InitializeComponent();
            listView.ItemsSource = Items;
            //listView.ItemAppearing += ListView_ItemAppearing;

            Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(300).ContinueWith( (t) => { if (t.Status == TaskStatus.RanToCompletion) Items.Add(i); });

                }
            });
        }



        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = (int)e.Item;
            //var listViewComponent = sender as ListView;
            var templatedItem = (ListView)sender;
            var x = templatedItem.ItemTemplate.Values;
        }

    }
}
