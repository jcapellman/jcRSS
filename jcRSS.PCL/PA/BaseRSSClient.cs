using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using jcRSS.PCL.Objects.Common;
using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.PCL.PA {
    public abstract class BaseRSSClient : BasePA {

        protected BaseRSSClient(BaseNetwork baseNetwork, SettingsContainer settings) : base(baseNetwork, settings) { }

        public abstract Task<List<FeedListingItem>> GetFeeds(string feedURL, DateTimeOffset lastPull);
        
        public abstract Task<FeedSiteItem> GetFeedInformation(string feedURL);

        public abstract Task<CTO<bool>> MarkAllRead();
    }
}