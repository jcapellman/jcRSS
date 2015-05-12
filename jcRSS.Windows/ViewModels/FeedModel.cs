using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using jcRSS.WindowsUniversal.Objects;

namespace jcRSS.WindowsUniversal.ViewModels {
    public class FeedModel : INotifyPropertyChanged {
        #region Collections
        private List<FeedContentItem> _feedListing;

        public List<FeedContentItem> FeedListing {
            get { return _feedListing; }

            set { _feedListing = value; OnPropertyChanged(); }
        }
        
        #endregion

        public async void LoadData() {
            FeedListing = new List<FeedContentItem>();

            App.Feeds.Add(new FeedItem {
                Description = "Putting 1s and 0s to work since 1995",
                ID = Guid.NewGuid(),
                Items = new List<FeedContentItem>(),
                Name = "Jarred Capellman",
                LastUpdate = DateTime.MinValue,
                UnreadCount = 0,
                URL = "http://www.jarredcapellman.com/feed"
            });

            await GetFeedAsync(App.Feeds[0].URL);
        }

        private async Task<FeedItem> GetFeedAsync(string feedUriString) {
            var client = new SyndicationClient();
            var feedUri = new Uri(feedUriString);

            try {
                SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);

                FeedItem feedData = new FeedItem();

                if (feed.Title != null && feed.Title.Text != null) {
                    feedData.Name = feed.Title.Text;
                }
                if (feed.Subtitle != null && feed.Subtitle.Text != null) {
                    feedData.Description = feed.Subtitle.Text;
                }

                if (feed.Items != null && feed.Items.Count > 0) {
                    feedData.LastUpdate = feed.Items[0].PublishedDate.DateTime;

                    foreach (SyndicationItem item in feed.Items) {
                        FeedContentItem feedItem = new FeedContentItem();
                        if (item.Title != null && item.Title.Text != null) {
                            feedItem.Title = item.Title.Text;
                        }

                        if (item.PublishedDate != null) {
                            feedItem.ContentPostDate = item.PublishedDate.DateTime;
                        }

                        if (item.Authors != null && item.Authors.Count > 0) {
                            feedItem.Author = item.Authors[0].Name.ToString();
                        }

                        if (feed.SourceFormat == SyndicationFormat.Atom10) {
                            if (item.Content != null && item.Content.Text != null) {
                                feedItem.Body = item.Content.Text;
                            }
                            if (item.Id != null) {
                                feedItem.URL = new Uri("http://windowsteamblog.com" + item.Id);
                            }
                        } else if (feed.SourceFormat == SyndicationFormat.Rss20) {
                            if (item.Summary != null && item.Summary.Text != null) {
                                feedItem.Body = item.Summary.Text;
                            }
                            if (item.Links != null && item.Links.Count > 0) {
                                feedItem.URL = item.Links[0].Uri;
                            }
                        }

                        feedData.Items.Add(feedItem);
                    }
                }
                return feedData;
            } catch (Exception) {
                return null;
            }
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
