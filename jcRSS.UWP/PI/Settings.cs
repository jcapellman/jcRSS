using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using jcRSS.PCL.PA;

namespace jcRSS.UWP.PI {
    public class Settings : BaseSettings {

        public override void LoadSettings()
        {
            var folder = ApplicationData.Current.RoamingSettings;

           
        }

        public override void WriteSettings()
        {
            throw new NotImplementedException();
        }
    }
}
