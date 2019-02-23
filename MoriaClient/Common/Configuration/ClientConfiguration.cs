using System;
using System.Collections.Generic;

namespace MoriaClient.Common.Configuration
{
    /// <summary>
    /// Represents Moria Client configuration
    /// </summary>
    public sealed class ClientConfiguration
    {
        /// <summary>
        /// Gets the base url to Moria API
        /// </summary>
        public Uri BaseApiUri { get; }

        /// <summary>
        /// Gets a read-only dictionary of configured endpoints
        /// </summary>
        public IReadOnlyDictionary<EndpointType, string> Endpoints { get; }

        internal ClientConfiguration(string baseApiUrl, IReadOnlyDictionary<EndpointType, string> endpoints)
        {
            BaseApiUri = new Uri(baseApiUrl);
            Endpoints = endpoints;
        }
    }
}