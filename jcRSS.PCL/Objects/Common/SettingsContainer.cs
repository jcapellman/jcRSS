using System;
using System.Collections.Generic;

using jcRSS.PCL.Enums;

namespace jcRSS.PCL.Objects.Common {
    public class SettingsContainer {
        public readonly Dictionary<string, object> SettingsDICT;

        public SettingsContainer() {
            SettingsDICT = new Dictionary<string, object>();
        }

        public T GetSetting<T>(SETTINGS setting) {
            return GetSetting<T>(setting.ToString());
        }

        private T GetSetting<T>(string setting) {
            if (!SettingsDICT.ContainsKey(setting)) {
                return default(T);
            }

            return (T)Convert.ChangeType(SettingsDICT[setting], typeof(T));
        }

        public bool WriteSetting(SETTINGS setting, object value) {
            return WriteSetting(setting.ToString(), value);
        }

        private bool WriteSetting(string setting, object value) {
            if (SettingsDICT.ContainsKey(setting)) {
                SettingsDICT[setting] = value;
            } else {
                SettingsDICT.Add(setting, value);
            }

            return true;
        }
    }
}