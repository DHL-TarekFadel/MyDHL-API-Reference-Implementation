using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters
{
    public class CustomJSONTimespanConverter : JsonConverter<TimeSpan>
    {
        private string _formatString;

        public CustomJSONTimespanConverter(string format)
        {
            _formatString = format.Replace(":", "\\:");
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            var timespanFormatted = $"{value.ToString(_formatString)}";
            writer.WriteValue(timespanFormatted);
        }

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            TimeSpan.TryParseExact((string)reader.Value, _formatString, null, out TimeSpan parsedTimeSpan);
            return parsedTimeSpan;
        }
    }
}
