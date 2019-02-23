using System;

namespace MoriaClient.Configuration
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
        /// Gets the path to teacher list endpoint relative to Moria API base url
        /// </summary>
        public string TeacherListEndpoint { get; }

        internal ClientConfiguration(string baseApiUrl, string teacherListEndpoint)
        {
            BaseApiUri = new Uri(baseApiUrl);
            TeacherListEndpoint = teacherListEndpoint;
        }
    }
}