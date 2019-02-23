using System;
using System.Net.Http;
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
    }
}