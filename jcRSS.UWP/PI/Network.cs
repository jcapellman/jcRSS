using System.Net.NetworkInformation;

using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class Network : BaseNetwork {
        public override bool IsNetworkAvailable() {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}