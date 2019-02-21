namespace MoriaClient.Teachers.Models
{
    /// <summary>
    /// Represents academic teacher
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Teachers Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Teachers degree/title
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Id of department which is lowest in hierarchy and hires teacher
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Teachers first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Teachers last name
        /// </summary>
        public string LastName { get; set; }
    }
}