namespace MoriaClient.Common.Configuration
{
    /// <summary>
    /// Represends Moria endpoint type
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
        Room
    }
}