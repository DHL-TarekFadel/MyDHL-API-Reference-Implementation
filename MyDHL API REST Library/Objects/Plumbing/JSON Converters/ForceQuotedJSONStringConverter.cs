using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters
{
    public class ForceQuotedJSONStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != objectType);

            return objectType.IsPrimitive;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "The result must be lower case.")]
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != writer);
            System.Diagnostics.Contracts.Contract.Requires(null != value);

            writer.WriteValue(value.ToString().ToLower(System.Globalization.CultureInfo.InvariantCulture));
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
