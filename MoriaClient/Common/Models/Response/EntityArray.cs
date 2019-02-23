using System.Runtime.Serialization;

namespace MoriaClient.Common.Models.Response
{
    [DataContract]
    internal sealed class EntityArray<T> where T : class
    {
        [DataMember(Name = "array")]
        public T[] Elements { get; set; }
    }
}