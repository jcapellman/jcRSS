using jcRSS.UWP.PI;

using Template10.Mvvm;

namespace jcRSS.UWP.ViewModels {
    public class BaseViewModel : ViewModelBase {
        public FileSystem _FileSystem = new FileSystem();
        public RSSClient _rssClient = new RSSClient();
        public Network _network = new Network();
    }
}