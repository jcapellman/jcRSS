using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using jcRSS.PCL.Handlers;
using jcRSS.PCL.Transports.Content;
using jcRSS.PCL.Transports.Feeds;

namespace jcRSS.WindowsUniversal.ViewModels {
    public class FeedModel : INotifyPropertyChanged {
        #region Collections
        private List<FeedListingResponseItem> _feedListing;

        public List<FeedListingResponseItem> FeedListing {
            get { return _feedListing; }

            set { _feedListing = value; OnPropertyChanged(); }
        }

        private List<ContentListingResponseItem> _contentListing;

        public List<ContentListingResponseItem> ContentListing {
            get { return _contentListing; }

            set { _contentListing = value; OnPropertyChanged(); }
        }
        #endregion

        public async void LoadData() {
            var feedHandler = new FeedHandler(App.REQUEST_ITEM);

            FeedListing = await feedHandler.GetFeed();

            var contentHandler = new ContentHandler(App.REQUEST_ITEM);

            ContentListing = await contentHandler.GetContent();
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
