using MoriaClient.Common.Configuration;
using System;

namespace MoriaClient.Rooms.Factories
{
    /// <summary>
    /// Factory that creates <see cref="IQueryRoomsData"/> objects.
    /// </summary>
    public static class RoomQueryFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IQueryRoomsData"/> which uses supplied configuration.
        /// </summary>
        /// <param name="configuration">Configuration created by <see cref="ConfigurationBuilder"/> that will be used by current <see cref="IQueryRoomsData"/> instance.</param>
        public static IQueryRoomsData CreateQuery(ClientConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new QueryRoomsData(configuration);
        }
    }
}