using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using jcRSS.UWP.ViewModels;

namespace jcRSS.UWP.Views {
    public sealed partial class DetailPage : Page {
        public DetailPage() {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DetailPageViewModel ViewModel => DataContext as DetailPageViewModel;
    }
}

