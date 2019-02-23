using MoriaClient.Configuration;
using System;

namespace MoriaClient.Teachers.Factories
{
    /// <summary>
    /// Factory that creates <see cref="IQueryTeachersData"/> objects.
    /// </summary>
    public static class TeacherQueryFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IQueryTeachersData"/> which uses supplied configuration.
        /// </summary>
        /// <param name="configuration">Configuration created by <see cref="ConfigurationBuilder"/> that will be used by current <see cref="IQueryTeachersData"/> instance.</param>
        public static IQueryTeachersData CreateQuery(ClientConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new QueryTeachersData(configuration);
        }
    }
}