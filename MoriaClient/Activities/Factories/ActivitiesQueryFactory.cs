using MoriaClient.Common.Configuration;
using System;

namespace MoriaClient.Activities.Factories
{
    /// <summary>
    /// Factory that creates <see cref="IQueryActivitiesData"/> objects.
    /// </summary>
    public static class ActivitiesQueryFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IQueryActivitiesData"/> which uses supplied configuration.
        /// </summary>
        /// <param name="configuration">Configuration created by <see cref="ConfigurationBuilder"/> that will be used by current <see cref="IQueryCoursesData"/> instance.</param>
        public static IQueryActivitiesData CreateQuery(ClientConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new QueryActivitiesData(configuration);
        }
    }
}