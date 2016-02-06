using jcRSS.PCL.Objects.Common;

namespace jcRSS.PCL.PA {
    public abstract class BaseSettings {
        protected SettingsContainer _SettingsContainer;

        public abstract void LoadSettings();

        public abstract void WriteSettings();
    }
}