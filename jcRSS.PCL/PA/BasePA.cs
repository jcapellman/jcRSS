using jcRSS.PCL.Objects.Common;

using Newtonsoft.Json;

namespace jcRSS.PCL.PA {
    public class BasePA {
        internal BaseNetwork _network;
        protected internal SettingsContainer _settings;

        public BasePA(BaseNetwork network, SettingsContainer settings) {
            _network = network;
            _settings = settings;
        }

        protected static byte[] GetBytesFromT<T>(T obj) {
            var jsonStr = GetJSONStringFromT(obj);

            var bytes = new byte[jsonStr.Length * sizeof(char)];

            System.Buffer.BlockCopy(jsonStr.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }

        protected static T GetObjectFromBytes<T>(byte[] bytes) {
            var chars = new char[bytes.Length / sizeof(char)];

            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);

            return JsonConvert.DeserializeObject<T>(new string(chars));
        }

        protected static string GetJSONStringFromT<T>(T obj) { return JsonConvert.SerializeObject(obj); }

        protected static T GetObjectFromJSONString<T>(string str) { return JsonConvert.DeserializeObject<T>(str); }
    }
}