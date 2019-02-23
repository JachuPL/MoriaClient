using System;

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
        /// Gets the path to teacher list endpoint relative to Moria API base url
        /// </summary>
        public string TeacherListEndpoint { get; }

        /// <summary>
        /// Gets the path to teacher entity endpoint relative to Moria API base url
        /// </summary>
        public string TeacherEntityEndpoint { get; }

        internal ClientConfiguration(string baseApiUrl, string teacherListEndpoint, string teacherEntityEndpoint)
        {
            BaseApiUri = new Uri(baseApiUrl);
            TeacherListEndpoint = teacherListEndpoint;
            TeacherEntityEndpoint = teacherEntityEndpoint;
        }
    }
}