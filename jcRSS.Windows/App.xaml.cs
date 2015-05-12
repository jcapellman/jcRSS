using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

using jcRSS.WindowsUniversal.Common;
using jcRSS.WindowsUniversal.Objects;

namespace jcRSS.WindowsUniversal {
    sealed partial class App : BootStrapper {
        public App() {
            this.InitializeComponent();

            Feeds = new ObservableCollection<FeedItem>();
        }

        public static ObservableCollection<FeedItem> Feeds { get; set; }

        public override Task OnInitializeAsync() {
            Window.Current.Content = new Views.Shell(this.RootFrame);
            return base.OnInitializeAsync();
        }

        public override Task OnLaunchedAsync(ILaunchActivatedEventArgs e) {
            this.NavigationService.Navigate(typeof(MainPage));
            return Task.FromResult<object>(null);
        }
    }
}