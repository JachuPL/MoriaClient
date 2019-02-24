using System.Runtime.Serialization;

namespace MoriaClient.Activities.Models
{
    /// <summary>
    /// Event being a part of an activity
    /// </summary>
    [DataContract]
    public class ActivityEvent
    {
        /// <summary>
        /// Id of an event
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Day of week event occurs
        /// </summary>
        [DataMember(Name = "weekday")]
        public WeekDay Day { get; set; }

        /// <summary>
        /// Time at which event starts
        /// </summary>
        [DataMember(Name = "start_time")]
        public string Start { get; set; }

        /// <summary>
        /// Event duration
        /// </summary>
        [DataMember(Name = "length")]
        public string Duration { get; set; }

        /// <summary>
        /// Event break length
        /// </summary>
        [DataMember(Name = "break_length")]
        public string BreakLength { get; set; }

        /// <summary>
        /// Event end date
        /// </summary>
        [DataMember(Name = "end_time")]
        public string Ends { get; set; }

        /// <summary>
        /// Id of room event takes place
        /// </summary>
        [DataMember(Name = "room_id")]
        public int RoomId { get; set; }

        /// <summary>
        /// Name of room event takes place
        /// </summary>
        [DataMember(Name = "room")]
        public string RoomName { get; set; }
    }
}