using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcRSS.PCL.Transports.Feeds {
    [DataContract]
    public class FeedListingResponseItem {
        [DataMember]
        public int FeedID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int NumUnread { get; set; }
    }
}