using MoriaClient.Common.Configuration;
using System;

namespace MoriaClient.Courses.Factories
{
    /// <summary>
    /// Factory that creates <see cref="IQueryCoursesData"/> objects.
    /// </summary>
    public static class CourseQueryFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IQueryCoursesData"/> which uses supplied configuration.
        /// </summary>
        /// <param name="configuration">Configuration created by <see cref="ConfigurationBuilder"/> that will be used by current <see cref="IQueryCoursesData"/> instance.</param>
        public static IQueryCoursesData CreateQuery(ClientConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new QueryCoursesData(configuration);
        }
    }
}