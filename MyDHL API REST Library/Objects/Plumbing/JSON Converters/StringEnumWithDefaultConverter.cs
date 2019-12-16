using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters
{
    public class StringEnumWithDefaultConverter : StringEnumConverter
    {
        public Enum DefaultValue { get; set; } = null;

        public StringEnumWithDefaultConverter(Enum defaultValue)
        {
            this.DefaultValue = defaultValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (JsonSerializationException)
            {
                return DefaultValue;
            }
        }
    }
}
