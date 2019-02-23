using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MoriaClient.Common
{
    internal static class JsonProcessor
    {
        public static T GetObjectFromStream<T>(Stream inputStream) where T : class
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            return jsonSerializer.ReadObject(inputStream) as T;
        }

        public static string GetStringFromObject<T>(T instance) where T : class
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (Stream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, instance);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    return sr.ReadToEnd();
            }
        }
    }
}