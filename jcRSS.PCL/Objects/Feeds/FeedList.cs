using System.Collections.Generic;
using System.Runtime.Serialization;

namespace jcRSS.PCL.Objects.Feeds {
    [DataContract]
    public class FeedList {
        [DataMember]
        public List<FeedSiteItem> FeedSites { get; set; } 
    }
}