using System;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace jcRSS.UWP.ViewModels {
    public class SettingsPageViewModel : ViewModelBase {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPartViewModel() {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                _settings = Services.SettingsServices.SettingsService.Instance;
        }

        private string _BusyText = "Please wait...";
        public string BusyText
        {
            get { return _BusyText; }
            set { Set(ref _BusyText, value); }
        }

        public void ShowBusy() {
            Views.Shell.SetBusy(true, _BusyText);
        }

        public void HideBusy() {
            Views.Shell.SetBusy(false);
        }
    }

    public class AboutPartViewModel : ViewModelBase {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://bing.com");
    }
}

