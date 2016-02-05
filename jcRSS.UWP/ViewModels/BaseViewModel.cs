using jcRSS.PCL.Objects.Common;
using jcRSS.UWP.PI;

using Template10.Mvvm;

namespace jcRSS.UWP.ViewModels {
    public class BaseViewModel : ViewModelBase {
        public FileSystem _FileSystem = new FileSystem(new Network(), new SettingsContainer());
        public RSSClient _rssClient = new RSSClient(new Network(), new SettingsContainer());
    }
}