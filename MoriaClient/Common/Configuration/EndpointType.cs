namespace MoriaClient.Common.Configuration
{
    /// <summary>
    /// Represents Moria endpoint type
    /// </summary>
    public enum EndpointType
    {
        /// <summary>
        /// Endpoint that allows to retrieve list of teachers
        /// </summary>
        TeacherList,

        /// <summary>
        /// Endpoint that allows to retrieve single teacher by id
        /// </summary>
        Teacher,

        /// <summary>
        /// Endpoint that allows to retrieve list of rooms
        /// </summary>
        RoomList,

        /// <summary>
        /// Endpoint that allows to retrieve single room by id
        /// </summary>
        Room,

        /// <summary>
        /// Endpoint that allows to retrieve list of courses
        /// </summary>
        CourseList,

        /// <summary>
        /// Endpoint that allows to retrieve single course by id
        /// </summary>
        Course
    }
}