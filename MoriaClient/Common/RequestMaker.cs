using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoriaClient.Common
{
    internal static class RequestMaker
    {
        public static async Task<HttpResponseMessage> GetResource(Uri endpoint, string json)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = endpoint;
                // TODO: make this come from config

                client.DefaultRequestHeaders.UserAgent.Add(GetDefaultUserAgent());

                using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        requestMessage.Content = content;

                        return await client.SendAsync(requestMessage);
                    }
                }
            }
        }

        private static ProductInfoHeaderValue GetDefaultUserAgent()
        {
            // TODO: make version come from config
            ProductHeaderValue header = new ProductHeaderValue("MoriaClient", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            return new ProductInfoHeaderValue(header);
        }
    }
}