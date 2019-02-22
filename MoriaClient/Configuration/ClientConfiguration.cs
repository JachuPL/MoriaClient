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

        /// <summary>
        /// Gets the path to teacher list endpoint relative to Moria API base url
        /// </summary>
        public string TeacherListEndpoint { get; }

        internal ClientConfiguration(string apiUrl, string teacherListEndpoint)
        {
            ApiUri = new Uri(apiUrl);
            TeacherListEndpoint = teacherListEndpoint;
        }
    }
}