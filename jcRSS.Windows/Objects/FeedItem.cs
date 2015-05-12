using System;
using System.Collections.Generic;

namespace jcRSS.WindowsUniversal.Objects {
    public class FeedItem {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        public int UnreadCount { get; set; }

        public DateTime LastUpdate { get; set; }

        private List<FeedContentItem> _Items = new List<FeedContentItem>();

        public List<FeedContentItem> Items {
            get { return this._Items; }

            set { this._Items = value; }
        }
    }
}