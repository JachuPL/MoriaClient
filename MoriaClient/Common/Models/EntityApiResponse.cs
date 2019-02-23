using System.Runtime.Serialization;

namespace MoriaClient.Common.Models
{
    [DataContract]
    internal sealed class EntityApiResponse<T> : AbstractApiResponse where T : class
    {
        [DataMember(Name = "result", IsRequired = false)]
        public T Result { get; set; }
    }
}