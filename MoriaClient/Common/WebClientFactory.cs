using System.Configuration;
using System.Net;
using System.Runtime.CompilerServices;

namespace MoriaClient.Common
{
    internal static class WebClientFactory
    {
        internal static WebClient CreateClient()
        {
            string baseUrl = ConfigurationManager.AppSettings["MoriaApiUrl"];
            return new WebClient
            {
                BaseAddress = baseUrl
            };
        }
    }
}