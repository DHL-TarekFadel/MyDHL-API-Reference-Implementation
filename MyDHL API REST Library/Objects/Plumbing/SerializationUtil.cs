using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyDHLAPI_REST_Library.Objects.Plumbing
{
    public static class SerializationUtil
    {
        public static T Deserialize<T>(XDocument doc)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != doc);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (var reader = doc.Root.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static XDocument Serialize<T>(T value)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != value);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                xmlSerializer.Serialize(writer, value);
            }

            return doc;
        }
    }
}
