using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ButtleShip_MVVM.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T fieald, T value, [CallerMemberName] string propertyName = "")
        {
            if (!fieald.Equals(value)) 
            {
                fieald = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected static void NavigateToPage(Page page, Uri uri)
        {
            NavigationService.GetNavigationService(page).Navigate(uri);
        }
    }
}
