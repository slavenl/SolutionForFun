using System.IO;
using System.Xml.Serialization;

namespace WebApiService.Helpers
{
    public class XmlDeserializer<T> where T : class
    {
        public static T DeserializeXmlData(Stream content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            T joinData = serializer.Deserialize(content) as T;

            return joinData;
        }
    }
}
