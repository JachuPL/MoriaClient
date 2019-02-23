using MoriaClient.Rooms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoriaClient.Rooms
{
    /// <summary>
    /// Allows to query room-related data
    /// </summary>
    public interface IQueryRoomsData
    {
        /// <summary>
        /// Returns list of all rooms
        /// </summary>
        Task<IEnumerable<Room>> GetAll();

        /// <summary>
        /// Returns list of rooms with ids passed in parameter
        /// </summary>
        /// <param name="idList">List of rooms ids</param>
        Task<IEnumerable<Room>> GetWithId(params int[] idList);

        /// <summary>
        /// Returns single room by id
        /// </summary>
        /// <param name="id">Id of room to retrieve</param>
        Task<Room> Get(int id);
    }
}