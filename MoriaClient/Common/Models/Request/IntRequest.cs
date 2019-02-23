using System.Runtime.Serialization;

namespace MoriaClient.Common.Models.Request
{
    [DataContract]
    internal class IntRequest
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        public IntRequest(int id)
        {
            Id = id;
        }
    }
}