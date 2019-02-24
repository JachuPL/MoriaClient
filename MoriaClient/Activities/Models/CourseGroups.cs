using System.Runtime.Serialization;

namespace MoriaClient.Activities.Models
{
    /// <summary>
    /// Brief description of course groups being able to participate in an activity
    /// </summary>
    [DataContract]
    public class CourseGroups
    {
        /// <summary>
        /// Course id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Course name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of course group participating in activity, indexed from 1
        /// </summary>
        [DataMember(Name = "group")]
        public int GroupId { get; set; }

        /// <summary>
        /// Total number of current course groups in activity
        /// </summary>
        [DataMember(Name = "groups")]
        public int TotalGroups { get; set; }
    }
}