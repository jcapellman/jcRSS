using System;
using System.Runtime.Serialization;

namespace jcRSS.PCL.Objects.Feeds {
    public class FeedListingItem {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string FeedSiteTitle { get; set; }

        [DataMember]
        public DateTime PostTime { get; set; }
    }
}