using MoriaClient.Teachers.Models;
using System.Collections.Generic;

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
        IEnumerable<Teacher> GetAll();

        /// <summary>
        /// Returns list of teachers with ids passed in parameter
        /// </summary>
        /// <param name="idList">List of teachers ids</param>
        IEnumerable<Teacher> GetWithId(params int[] idList);

        /// <summary>
        /// Returns single teacher by id
        /// </summary>
        /// <param name="id">Id of teacher to retrieve</param>
        Teacher Get(int id);
    }
}