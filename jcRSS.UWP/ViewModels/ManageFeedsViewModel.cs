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

        private FeedList _feedList;

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

        public async void AddFeedSite() {
            var feedSite = await _rssClient.GetFeedInformation(FeedSiteURL);

            _feedList.FeedSites.Add(feedSite);

            var result = await _FileSystem.WriteFile(FILE_TYPES.FEED_LIST, _feedList);            
        }
    }
}