using Prism.Mvvm;
using Prism.Navigation;

namespace VastGoed.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
