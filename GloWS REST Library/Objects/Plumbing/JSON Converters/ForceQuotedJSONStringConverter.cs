using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters
{
    public class ForceQuotedJSONStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsPrimitive;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().ToLower());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
