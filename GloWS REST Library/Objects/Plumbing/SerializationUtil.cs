using System.Xml.Linq;
using System.Xml.Serialization;

namespace GloWS_REST_Library.Objects.Plumbing
{
    public static class SerializationUtil
{
    public static T Deserialize<T>(XDocument doc)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        using (var reader = doc.Root.CreateReader())
        {
            return (T)xmlSerializer.Deserialize(reader);
        }
    }

    public static XDocument Serialize<T>(T value)
    {
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
