using MoriaClient.Activities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoriaClient.Activities
{
    /// <summary>
    /// Allows to query activities-related data
    /// </summary>
    public interface IQueryActivitiesData
    {
        /// <summary>
        /// Returns single activity by id
        /// </summary>
        /// <param name="id">Id of activity to retrieve</param>
        Task<Activity> Get(int id);

        /// <summary>
        /// Returns list of activities taking place in a room with selected id
        /// </summary>
        /// <param name="roomId">Id of room activities take place in</param>
        Task<IEnumerable<Activity>> GetByRoom(int roomId);

        /// <summary>
        /// Returns list of activities being a part of a course with selected id
        /// </summary>
        /// <param name="courseId">Id of course activities belong to</param>
        Task<IEnumerable<Activity>> GetByCourse(int courseId);

        /// <summary>
        /// Returns list of activities lead by teacher with selected id
        /// </summary>
        /// <param name="teacherId">Id of teacher leading activities</param>
        Task<IEnumerable<Activity>> GetByTeacher(int teacherId);
    }
}