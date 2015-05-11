using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

using jcRSS.PCL.Transports.Internal;
using jcRSS.WindowsUniversal.Common;

namespace jcRSS.WindowsUniversal {
    sealed partial class App : BootStrapper {
        public App() {
            this.InitializeComponent();
        }

        public static RequestItem REQUEST_ITEM { get; set; }

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