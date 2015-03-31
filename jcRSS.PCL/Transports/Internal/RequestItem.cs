using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcRSS.PCL.Transports.Internal {
    [DataContract]
    public class RequestItem {
        [DataMember]
        public int? UserID { get; set; }

        [DataMember(IsRequired = true)]
        public string WebAPIAddress { get; set; }
    }
}