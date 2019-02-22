using MoriaClient.Teachers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoriaClient.Teachers
{
    /// <summary>
    /// Allows to query teachers-related data
    /// </summary>
    public interface IQueryTeachersData
    {
        /// <summary>
        /// Returns list of all teachers
        /// </summary>
        Task<IEnumerable<Teacher>> GetAll();

        /// <summary>
        /// Returns list of teachers with ids passed in parameter
        /// </summary>
        /// <param name="idList">List of teachers ids</param>
        Task<IEnumerable<Teacher>> GetWithId(params int[] idList);

        /// <summary>
        /// Returns single teacher by id
        /// </summary>
        /// <param name="id">Id of teacher to retrieve</param>
        Task<Teacher> Get(int id);
    }
}