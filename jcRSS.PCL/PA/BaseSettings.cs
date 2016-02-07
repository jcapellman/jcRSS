using jcRSS.PCL.Enums;
using jcRSS.PCL.Objects.Common;

namespace jcRSS.PCL.PA {
    public abstract class BaseSettings {
        protected SettingsContainer _SettingsContainer;

        public abstract void LoadSettings();

        public abstract void WriteSettings();

        public abstract T Get<T>(SETTINGS setting);

        public abstract void Set(SETTINGS setting, object value);
    }
}