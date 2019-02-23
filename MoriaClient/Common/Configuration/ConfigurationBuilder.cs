using System;
using System.Collections.Generic;

namespace MoriaClient.Common.Configuration
{
    /// <summary>
    /// Allows to configure different MoriaClient options
    /// </summary>
    public class ConfigurationBuilder
    {
        private string _apiUrl = string.Empty;
        private readonly Dictionary<EndpointType, string> _endpoints = new Dictionary<EndpointType, string>();

        /// <summary>
        /// Changes base Moria API url
        /// </summary>
        /// <param name="apiUrl">Url to Moria API</param>
        public ConfigurationBuilder WithApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
            return this;
        }

        /// <summary>
        /// Adds an endpoint of specific type to endpoint dictionary.
        /// </summary>
        /// <param name="type">The type of endpoint to add</param>
        /// <param name="endpoint">The endpoint url relative to base Moria API url</param>
        /// <returns></returns>
        public ConfigurationBuilder AddEndpoint(EndpointType type, string endpoint)
        {
            if (!Enum.IsDefined(typeof(EndpointType), type))
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }
            _endpoints[type] = endpoint;
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

            return new ClientConfiguration(_apiUrl, _endpoints);
        }

        private bool IsProvidedUrlAValidHttpOrHttpsUrl(string apiUrl)
        {
            return Uri.TryCreate(apiUrl, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}