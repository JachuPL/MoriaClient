using System;
using System.Net.Http;

namespace MoriaClient.Common
{
    internal class HttpClientFactory
    {
        private readonly Uri _baseUri;

        public HttpClientFactory(Uri baseUri)
        {
            _baseUri = baseUri ?? throw new ArgumentNullException(nameof(Configuration));
        }

        internal HttpClient CreateClient()
        {
            return new HttpClient()
            {
                BaseAddress = _baseUri
            };
        }
    }
}