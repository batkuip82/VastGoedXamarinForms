using Prism.Navigation;
using Xamarin.Forms;

namespace VastGoed.Views
{
    public partial class MasterPageView : MasterDetailPage, IMasterDetailPageOptions
    {
        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }

        public MasterPageView()
        {
            InitializeComponent();
        }
    }
}
