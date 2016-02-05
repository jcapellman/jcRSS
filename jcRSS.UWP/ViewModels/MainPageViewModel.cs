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

        private bool _refreshEnabled;

        public bool RefreshEnabled {
            get {  return _refreshEnabled; }
            set { _refreshEnabled = value; RaisePropertyChanged(); }
        }

        private bool _markAsReadEnabled;

        public bool MarkAsReadEnabled {
            get { return _markAsReadEnabled; }
            set { _markAsReadEnabled = value; RaisePropertyChanged(); }
        }

        private async Task<bool> LoadFeed() {
            RefreshEnabled = false;
            
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

            for (var x = 0; x < feedList.FeedSites.Count; x++) {
                FeedListing.AddRange(await _rssClient.GetFeeds(feedList.FeedSites[x].URL, feedList.FeedSites[x].LastPull));

                feedList.FeedSites[x].LastPull = DateTimeOffset.Now;
            }

            var updateResult = await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, feedList);

            FeedListing = new ObservableCollection<FeedListingItem>(FeedListing.OrderByDescending(a => a.PostTime));

            RefreshEnabled = true;

            return true;
        }

        public async void MarkAsRead() {
            var result = await _rssClient.MarkAllRead();

            if (result.HasError) {
                throw new Exception(result.Exception);
            }
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