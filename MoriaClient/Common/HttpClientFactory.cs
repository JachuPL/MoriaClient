using MoriaClient.Configuration;
using System;
using System.Net.Http;

namespace MoriaClient.Common
{
    internal static class HttpClientFactory
    {
        internal static HttpClient CreateClient(ClientConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            HttpClient client = new HttpClient()
            {
                BaseAddress = configuration.ApiUri
            };

            return client;
        }
    }
}