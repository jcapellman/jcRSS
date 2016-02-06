using jcRSS.PCL.Objects.Common;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class Settings : BaseSettings {
        private readonly Windows.Storage.ApplicationDataContainer _localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        public override void LoadSettings() {
            _SettingsContainer = new SettingsContainer();
        }

        public override void WriteSettings() {
            foreach (var setting in _SettingsContainer.SettingsDICT.Keys) {
                _localSettings.Values[setting] = _SettingsContainer.SettingsDICT[setting];
            }
        }
    }
}