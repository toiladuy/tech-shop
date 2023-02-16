using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Utils
{
    public class HttpUtils
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<T> PostAsync<T>(string uri, HttpContent content)
        {
            var response = await httpClient.PostAsync(uri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public static Task<T> PostFormAsync<T>(string uri, Dictionary<string, string> data)
        {
            return PostAsync<T>(uri, new FormUrlEncodedContent(data));
        }
    }
}
