using System;
using System.Runtime.Serialization;

namespace jcRSS.PCL.Objects.Feeds {
    [DataContract]
    public class FeedSiteItem {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public DateTimeOffset LastPull { get; set; }
    }
}