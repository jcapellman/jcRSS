using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Windows.UI.Xaml.Navigation;

using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Feeds;

using Template10.Utils;

namespace jcRSS.UWP.ViewModels {
    public class MainPageViewModel : BaseViewModel {
        private ObservableCollection<FeedListingItem> _feedListing;

        public ObservableCollection<FeedListingItem> FeedListing {
            get {  return _feedListing; }
            set { _feedListing = value; RaisePropertyChanged("FeedListing"); }
        } 

        public MainPageViewModel() { }

        private FeedListingItem _selectedFeedListingItem;

        public FeedListingItem SelectedFeedListingItem {
            get {  return _selectedFeedListingItem; }
            set { _selectedFeedListingItem = value; RaisePropertyChanged("SelectedFeedListingItem"); if (value != null) { GotoDetailsPage(); } }
        }

        private async Task<bool> LoadFeed() {
            var feeds = await _FileSystem.GetFile<FeedList>(FILE_TYPES.FEED_LIST);

            var feedList = new FeedList();

            if (feeds.HasError) {
                feedList = new FeedList {
                    FeedSites = new List<FeedSiteItem> {
                        new FeedSiteItem {
                            ID = 1,
                            Title = "Jarred Capellman",
                            URL = "http://www.jarredcapellman.com/rss.xml"
                        }
                    }
                };

                await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, feedList);
            } else {
                feedList = feeds.Value;
            }

            FeedListing = new ObservableCollection<FeedListingItem>();

            foreach (var feed in feedList.FeedSites) {
                FeedListing.AddRange(await _rssClient.GetFeeds(feed.URL));
            }

            FeedListing = new ObservableCollection<FeedListingItem>(FeedListing.OrderByDescending(a => a.PostTime));

            return true;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state) {
            var result = await LoadFeed();

            if (!result) {
                throw new Exception("Error loading feed");
            }
        }

        public async void RefreshFeed() => await LoadFeed();

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), SelectedFeedListingItem);
    }
}