using System.Runtime.Serialization;

namespace MoriaClient.Activities.Models
{
    /// <summary>
    /// Represents simplified teacher details
    /// </summary>
    [DataContract]
    public class SimplifiedTeacher
    {
        /// <summary>
        /// Id of a teacher
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Combined degree and teacher first name and last name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}