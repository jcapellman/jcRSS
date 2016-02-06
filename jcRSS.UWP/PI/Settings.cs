using System;

using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Common;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class Settings : BaseSettings {
        private readonly Windows.Storage.ApplicationDataContainer _localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

        private SETTINGS convertString(string key) {
            return (SETTINGS) Enum.Parse(typeof (SETTINGS), key);
        }

        public override void LoadSettings() {
            _SettingsContainer = new SettingsContainer();

            foreach (var setting in _localSettings.Values) {
                _SettingsContainer.WriteSetting(convertString(setting.Key), setting.Value);
            }
        }

        public override void WriteSettings() {
            foreach (var setting in _SettingsContainer.SettingsDICT.Keys) {
                _localSettings.Values[setting] = _SettingsContainer.SettingsDICT[setting];
            }
        }
    }
}