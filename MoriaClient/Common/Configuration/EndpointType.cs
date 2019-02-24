namespace MoriaClient.Common.Configuration
{
    /// <summary>
    /// Represents Moria endpoint type
    /// </summary>
    public enum EndpointType
    {
        /// <summary>
        /// Endpoint allowing to retrieve list of teachers
        /// </summary>
        TeacherList,

        /// <summary>
        /// Endpoint allowing to retrieve single teacher by id
        /// </summary>
        Teacher,

        /// <summary>
        /// Endpoint allowing to retrieve list of rooms
        /// </summary>
        RoomList,

        /// <summary>
        /// Endpoint allowing to retrieve single room by id
        /// </summary>
        Room,

        /// <summary>
        /// Endpoint allowing to retrieve list of courses
        /// </summary>
        CourseList,

        /// <summary>
        /// Endpoint allowing to retrieve single course by id
        /// </summary>
        Course,

        /// <summary>
        /// Endpoint allowing to retrieve list of activities taking place in a room
        /// </summary>
        ActivitiesByRoom,

        /// <summary>
        /// Endpoint allowing to retrieve list of activities by course
        /// </summary>
        ActivitiesByCourse,

        /// <summary>
        /// Endpoint allowing to retrieve list of activities by teacher
        /// </summary>
        ActivitiesByTeacher,

        /// <summary>
        /// Endpoint allowing to retrieve single activity by id
        /// </summary>
        Activity
    }
}