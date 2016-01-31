using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.UI.Xaml.Navigation;

using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.UWP.ViewModels {
    public class DetailPageViewModel : BaseViewModel {
        public DetailPageViewModel() { }

        private FeedListingItem _feedItem;

        public FeedListingItem FeedItem { get { return _feedItem; } set { _feedItem = value; RaisePropertyChanged("FeedItem"); } }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state) {
            FeedItem = (FeedListingItem)parameter;

            return Task.CompletedTask;
        }        
    }
}