using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcRSS.PCL.Transports.Users {
    [DataContract]
    public class UserProfileResponseItem {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}