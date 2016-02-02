using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.UWP.Views {

    public sealed partial class ManageFeeds : Page {
        public ManageFeeds() {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            ViewModel.SelectedFeedSites = lvFeeds.SelectedItems.Select(a => (FeedSiteItem)a).ToList();

            ViewModel.RemoveFeedSites();
        }
    }
}
