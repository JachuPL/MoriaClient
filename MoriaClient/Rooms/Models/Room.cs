using System.Runtime.Serialization;

namespace MoriaClient.Rooms.Models
{
    /// <summary>
    /// Represents classroom
    /// </summary>
    [DataContract]
    public class Room
    {
        /// <summary>
        /// Rooms Id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Rooms name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of department which is lowest in hierarchy and owns this room
        /// </summary>
        [DataMember(Name = "department_id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Rooms capacity
        /// </summary>
        [DataMember(Name = "quanitiy")]
        public int Capacity { get; set; }
    }
}