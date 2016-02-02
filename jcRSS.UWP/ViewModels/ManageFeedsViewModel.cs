using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Windows.UI.Xaml.Navigation;

using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.UWP.ViewModels {
    public class ManageFeedsViewModel : BaseViewModel  {
        private ObservableCollection<FeedSiteItem> _feedSiteListing;

        public ObservableCollection<FeedSiteItem> FeedSiteListing {
            get { return _feedSiteListing; }
            set { _feedSiteListing = value; RaisePropertyChanged("FeedSiteListing"); }
        }

        private string _feedSiteURL;

        public string FeedSiteURL {
            get {  return _feedSiteURL; }
            set { _feedSiteURL = value; RaisePropertyChanged("FeedSiteURL"); }
        }

        private List<FeedSiteItem> _selectedFeedSites;

        public List<FeedSiteItem> SelectedFeedSites {
            get { return _selectedFeedSites; }
            set { _selectedFeedSites = value; RaisePropertyChanged("SelectedFeedSites"); }
        } 
         
        private FeedList _feedList;

        public ManageFeedsViewModel() {
            SelectedFeedSites = new List<FeedSiteItem>();
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state) {
            var feeds = await _FileSystem.GetFile<FeedList>(FILE_TYPES.FEED_LIST);

            _feedList = new FeedList();

            if (feeds.HasError) {
                _feedList = new FeedList {
                    FeedSites = new List<FeedSiteItem> {
                        new FeedSiteItem {
                            ID = 1,
                            Title = "Jarred Capellman",
                            URL = "http://www.jarredcapellman.com/rss.xml"
                        }
                    }
                };

                await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, _feedList);
            } else {
                _feedList = feeds.Value;
            }

            FeedSiteListing = new ObservableCollection<FeedSiteItem>(_feedList.FeedSites);
        }

        public async void RemoveFeedSites() {
            foreach (var feedSite in SelectedFeedSites) {
                _feedList.FeedSites.Remove(feedSite);
            }

            await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, _feedList);

            SelectedFeedSites.Clear();

            FeedSiteListing = new ObservableCollection<FeedSiteItem>(_feedList.FeedSites);
        }

        public async void AddFeedSite() {
            var feedSite = await _rssClient.GetFeedInformation(FeedSiteURL);

            _feedList.FeedSites.Add(feedSite);

            var result = await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, _feedList);

            FeedSiteListing = new ObservableCollection<FeedSiteItem>(_feedList.FeedSites);

            FeedSiteURL = string.Empty;
        }
    }
}