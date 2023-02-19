using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Utils
{
    public class ZaloPayService
    {
        private static string appId = "2554";
        private static string key1 = "sdngKKJmqEMzvh5QQcdD2A9XBSKUNaYn";

        public static async Task<string> CreateOrder(string orderId, double amount, string redirectUrl, string callbackUrl, Dictionary<string, string> postbackData)
        {
            string endpoint = "https://sb-openapi.zalopay.vn/v2/create";
            long currentTs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string appTransId = DateTime.Now.ToString("yyMMdd") + "_" + orderId + "_" + new Random().Next(9999);
            string appUser = "PH-Tech";
            var embedData = new Dictionary<string, string>(postbackData)
            {
                { "redirecturl", redirectUrl }
            };
            string item = "[]";
            string rawHash = appId + "|" + appTransId + "|" + appUser + "|" + amount + "|" +
                currentTs + "|" + JsonConvert.SerializeObject(embedData) + "|" + item;
            string hmac = HmacUtils.Compute(key1, rawHash);
            var param = new Dictionary<string, string>
            {
                { "app_id", appId },
                { "app_trans_id", appTransId },
                { "app_user", appUser },
                { "app_time", currentTs.ToString() },
                { "amount", amount.ToString() },
                { "item", item },
                { "description", "PH-Tech - Thanh toán đơn hàng #" + appTransId },
                { "embed_data", JsonConvert.SerializeObject(embedData) },
                { "bank_code", "zalopayapp" },
                { "mac", hmac },
                { "callback_url", callbackUrl }
            };
            var result = await HttpUtils.PostFormAsync<JObject>(endpoint, param);
            return result.GetValue("order_url").ToString();
        }

        public static async Task<bool> IsOrderSuccess(string appTransId)
        {
            string endpoint = "https://sb-openapi.zalopay.vn/v2/query";
            string rawHash = appId + "|" + appTransId + "|" + key1;
            string hmac = HmacUtils.Compute(key1, rawHash);
            var param = new Dictionary<string, string>
            {
                { "app_id", appId },
                { "app_trans_id", appTransId },
                { "mac", hmac }
            };
            var result = await HttpUtils.PostFormAsync<JObject>(endpoint, param);
            var returnCode = int.Parse(result.GetValue("return_code").ToString());
            var isProcessing = bool.Parse(result.GetValue("is_processing").ToString());
            return returnCode == 1 && !isProcessing;
        }
    }
}
