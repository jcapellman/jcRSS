using System;

namespace jcRSS.WindowsUniversal.Objects {
    public class FeedContentItem {
        public DateTime ContentPostDate { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public Uri URL { get; set; }

        public string Author { get; set; }
    }
}