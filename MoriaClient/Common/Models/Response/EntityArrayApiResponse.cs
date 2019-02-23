using System.Runtime.Serialization;

namespace MoriaClient.Common.Models.Response
{
    [DataContract]
    internal sealed class EntityArrayApiResponse<T> : AbstractApiResponse where T : class
    {
        [DataMember(Name = "result", IsRequired = false)]
        public EntityArray<T> Result { get; set; }
    }
}