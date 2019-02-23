using System.Runtime.Serialization;

namespace MoriaClient.Courses.Models
{
    /// <summary>
    /// Represents university course
    /// </summary>
    [DataContract]
    public class Course
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
    }
}