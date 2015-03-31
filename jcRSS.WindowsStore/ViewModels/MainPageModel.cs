using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

using jcRSS.PCL.Handlers;
using jcRSS.PCL.Transports.Feeds;
using jcRSS.PCL.Transports.Content;

namespace jcRSS.WindowsStore.ViewModels {
    public class MainPageModel : INotifyPropertyChanged {
        public MainPageModel() { }

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
