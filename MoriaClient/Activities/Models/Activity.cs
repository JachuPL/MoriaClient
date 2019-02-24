using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoriaClient.Activities.Models
{
    /// <summary>
    /// Represents academic activity/event
    /// </summary>
    [DataContract]
    public class Activity
    {
        /// <summary>
        /// Activity's id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Activity subjects id
        /// </summary>
        [DataMember(Name = "subject_id")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Activity's subject name
        /// </summary>
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Events included in specified activity
        /// </summary>
        [DataMember(Name = "event_array")]
        public IEnumerable<ActivityEvent> Events { get; set; } = new List<ActivityEvent>();

        /// <summary>
        /// Courses that might take part in this activity
        /// </summary>
        [DataMember(Name = "students_array")]
        public IEnumerable<CourseGroups> CourseGroups { get; set; } = new List<CourseGroups>();

        /// <summary>
        /// Teachers bound to this activity
        /// </summary>
        [DataMember(Name = "teacher_array")]
        public IEnumerable<SimplifiedTeacher> Teachers { get; set; } = new List<SimplifiedTeacher>();
    }
}