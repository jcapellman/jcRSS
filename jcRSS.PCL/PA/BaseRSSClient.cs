using System.Collections.Generic;
using System.Threading.Tasks;

using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.PCL.PA {
    public abstract class BaseRSSClient : BasePA {
        public abstract Task<List<FeedListingItem>> GetFeeds(string feedURL);

        public abstract Task<FeedSiteItem> GetFeedInformation(string feedURL);
    }
}