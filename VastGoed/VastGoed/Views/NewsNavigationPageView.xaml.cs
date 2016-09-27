using Prism.Navigation;
using Xamarin.Forms;

namespace VastGoed.Views
{
    public partial class NewsNavigationPageView : NavigationPage, INavigationPageOptions
    {
        public NewsNavigationPageView()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get
            {
                return true;
            }
        }
    }
}
