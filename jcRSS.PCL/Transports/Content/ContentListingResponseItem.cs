using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcRSS.PCL.Transports.Content {
    [DataContract]
    public class ContentListingResponseItem {
        [DataMember]
        public int ContentFeedID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public DateTime PostDate { get; set; }
    }
}