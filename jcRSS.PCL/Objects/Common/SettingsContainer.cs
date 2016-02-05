using System;
using System.Collections.Generic;

using jcRSS.PCL.Enums;

namespace jcRSS.PCL.Objects.Common {
    public class SettingsContainer {
        private readonly Dictionary<string, object> _settings;

        public SettingsContainer() {
            _settings = new Dictionary<string, object>();
        }

        public T GetSetting<T>(SETTINGS setting) {
            return GetSetting<T>(setting.ToString());
        }

        private T GetSetting<T>(string setting) {
            if (!_settings.ContainsKey(setting)) {
                return default(T);
            }

            return (T)Convert.ChangeType(_settings[setting], typeof(T));
        }

        public bool WriteSetting(SETTINGS setting, object value) {
            return WriteSetting(setting.ToString(), value);
        }

        private bool WriteSetting(string setting, object value) {
            if (_settings.ContainsKey(setting)) {
                _settings[setting] = value;
            } else {
                _settings.Add(setting, value);
            }

            return true;
        }
    }
}