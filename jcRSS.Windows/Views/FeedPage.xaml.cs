using Windows.UI.Xaml.Controls;

using jcRSS.WindowsUniversal.ViewModels;

namespace jcRSS.WindowsUniversal.Views {
    public sealed partial class FeedPage : Page {
        public FeedPage() {
            this.InitializeComponent();

            DataContext = new FeedModel();

            ((FeedModel)DataContext).LoadData();
        }
    }
}