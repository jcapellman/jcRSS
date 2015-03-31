using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using jcRSS.PCL.Transports.Internal;

namespace jcRSS.PCL.Handlers {
    public class BaseHandler {
        private RequestItem _requestItem;

        public BaseHandler(RequestItem requestItem) {
            _requestItem = requestItem;
        }

        private HttpClient GetHttpClient() {
            var handler = new HttpClientHandler();

            var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(jcRSS.PCL.Common.Constants.CONST_WEBAPI_TIMEOUT) };

            if (_requestItem.UserID.HasValue) {
                client.DefaultRequestHeaders.Add("UserID", _requestItem.UserID.Value.ToString());
            }

            return client;
        }

        private string parseString(string urlArguments) {
            return urlArguments.Replace("=&", "=null&");
        }

        public async Task<T> Get<T>(string urlArguments) {
            try {
                var client = GetHttpClient();

                var str = await client.GetStringAsync(String.Format(_requestItem.WebAPIAddress + "{0}", parseString(urlArguments)));

                return JsonConvert.DeserializeObject<T>(str);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<K> Send<T, K>(string urlArguments, T obj) {
            try {
                var client = GetHttpClient();

                var address = new Uri(String.Format(_requestItem.WebAPIAddress + "{0}", urlArguments));
                var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(address, content);

                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<K>(data);
            } catch (Exception ex) {
                return JsonConvert.DeserializeObject<K>(ex.ToString());
            }
        }
    }
}
