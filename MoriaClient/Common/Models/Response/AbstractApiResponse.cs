using System.Runtime.Serialization;

namespace MoriaClient.Common.Models.Response
{
    [DataContract]
    internal abstract class AbstractApiResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public string Status { get; set; }

        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }
    }
}