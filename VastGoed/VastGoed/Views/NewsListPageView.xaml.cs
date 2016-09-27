
using Xamarin.Forms;

namespace VastGoed.Views
{
    public partial class NewsListPageView : ContentPage
    {


        public NewsListPageView()
        {
            InitializeComponent();

            //Set the converter in code-behind, because XAML previewer does not like StaticResources
            listView.SetBinding(ListView.IsVisibleProperty, new Binding("listView", BindingMode.Default,
                new Converters.InverseBooleanConverter(), null));
        }


    }
}
