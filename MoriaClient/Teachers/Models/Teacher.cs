using System.Runtime.Serialization;

namespace MoriaClient.Teachers.Models
{
    /// <summary>
    /// Represents academic teacher
    /// </summary>
    [DataContract]
    public class Teacher
    {
        /// <summary>
        /// Teachers Id
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Teachers degree/title
        /// </summary>
        [DataMember(Name = "degree")]
        public string Degree { get; set; }

        /// <summary>
        /// Id of department which is lowest in hierarchy and hires teacher
        /// </summary>
        [DataMember(Name = "department_id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Teachers first name
        /// </summary>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Teachers last name
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
    }
}