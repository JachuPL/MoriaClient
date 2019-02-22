using System;

namespace MoriaClient.Configuration
{
    /// <summary>
    /// Represents Moria Client configuration
    /// </summary>
    public sealed class ClientConfiguration
    {
        /// <summary>
        /// Gets the url to Moria API
        /// </summary>
        public Uri ApiUri { get; }

        internal ClientConfiguration(string apiUrl)
        {
            ApiUri = new Uri(apiUrl);
        }
    }
}