using MoriaClient.Courses.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoriaClient.Courses
{
    /// <summary>
    /// Allows to query course-related data
    /// </summary>
    public interface IQueryCoursesData
    {
        /// <summary>
        /// Returns list of all courses
        /// </summary>
        Task<IEnumerable<Course>> GetAll();

        /// <summary>
        /// Returns list of courses with ids passed in parameter
        /// </summary>
        /// <param name="idList">List of courses ids</param>
        Task<IEnumerable<Course>> GetWithId(params int[] idList);

        /// <summary>
        /// Returns single course by id
        /// </summary>
        /// <param name="id">Id of course to retrieve</param>
        Task<Course> Get(int id);
    }
}