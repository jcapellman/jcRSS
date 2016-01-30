using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Windows.Web.Syndication;

using jcRSS.PCL.Objects.Feeds;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class RSSClient : BaseRSSClient {
        public override async Task<List<FeedListingItem>> GetFeeds(string feedURL) {
            var feedClient = new SyndicationClient();

            var feeds = await feedClient.RetrieveFeedAsync(new Uri(feedURL));

            return feeds.Items.Select(feed => new FeedListingItem {
                FeedSiteTitle = feeds.Title.Text, PostTime = feed.PublishedDate.DateTime, ShortDescription = feed.Summary.Text, Title = feed.Title.Text
            }).ToList();
        }
    }
}