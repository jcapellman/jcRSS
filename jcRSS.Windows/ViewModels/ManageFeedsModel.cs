using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using jcRSS.WindowsUniversal.Objects;

namespace jcRSS.WindowsUniversal.ViewModels {
    public class ManageFeedsModel : INotifyPropertyChanged {
        public ManageFeedsModel() {  }

        public ObservableCollection<FeedItem> Feeds {
            get { return App.Feeds; }

            set { App.Feeds = value; OnPropertyChanged(); }
        }

        private FeedItem _newFeedItem;

        public FeedItem NewFeedItem {
            get { return _newFeedItem; }

            set { _newFeedItem = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddFeed() {
            Feeds.Add(NewFeedItem);
        }

        public void LoadData() {
            Feeds = App.Feeds;
        }
    }
}