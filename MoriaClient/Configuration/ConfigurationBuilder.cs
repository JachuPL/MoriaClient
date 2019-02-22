using System;

namespace MoriaClient.Configuration
{
    /// <summary>
    /// Allows to configure different MoriaClient options
    /// </summary>
    public class ConfigurationBuilder
    {
        private string _apiUrl = string.Empty;

        /// <summary>
        /// Changes Moria API url
        /// </summary>
        /// <param name="apiUrl">Url to Moria API</param>
        public ConfigurationBuilder WithUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
            return this;
        }

        /// <summary>
        /// Creates <see cref="ClientConfiguration"/> object based on builder pipeline
        /// </summary>
        public ClientConfiguration Build()
        {
            if (string.IsNullOrWhiteSpace(_apiUrl))
            {
                throw new ArgumentNullException($"API Url cannot be null, empty or built from whitespace characters.");
            }

            if (!IsProvidedUrlAValidHttpOrHttpsUrl(_apiUrl))
            {
                throw new ArgumentException($"The api url '{_apiUrl}' is not a valid HTTP or HTTPS url.");
            }

            return new ClientConfiguration(_apiUrl);
        }

        private bool IsProvidedUrlAValidHttpOrHttpsUrl(string apiUrl)
        {
            return Uri.TryCreate(_apiUrl, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}