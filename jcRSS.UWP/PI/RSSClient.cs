using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Windows.Web.Syndication;

using jcRSS.PCL.Objects.Feeds;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class RSSClient : BaseRSSClient {
        public override async Task<List<FeedListingItem>> GetFeeds(string feedURL, DateTimeOffset lastPull) {
            var feedClient = new SyndicationClient();

            var feeds = await feedClient.RetrieveFeedAsync(new Uri(feedURL));

            return feeds.Items.Where(a => a.Links != null && a.Links.Any() && a.LastUpdatedTime > lastPull).Select(feed => new FeedListingItem {
                FeedSiteTitle = feeds.Title?.Text ?? string.Empty, PostTime = feed.PublishedDate.DateTime, ShortDescription = feed.Summary?.Text ?? string.Empty, Title = feed.Title?.Text ?? string.Empty, URL = feed.Links.FirstOrDefault().Uri.ToString()
            }).ToList();
        }

        public override async Task<FeedSiteItem> GetFeedInformation(string feedURL) {
            var feedClient = new SyndicationClient();

            var feedInfo = await feedClient.RetrieveFeedAsync(new Uri(feedURL));

            return new FeedSiteItem {
                ID = 1,
                Title = feedInfo.Title.Text,
                URL = feedURL
            };
        }
    }
}