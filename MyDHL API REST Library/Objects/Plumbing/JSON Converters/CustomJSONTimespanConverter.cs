using Newtonsoft.Json;
using System;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters
{
    public class CustomJSONTimespanConverter : JsonConverter<TimeSpan>
    {
        private string _formatString;

        public CustomJSONTimespanConverter(string format)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != format);

            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException(nameof(format));
            }

            _formatString = format.Replace(":", "\\:");
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != writer);

            var timespanFormatted = $"{value.ToString(_formatString, System.Globalization.CultureInfo.InvariantCulture)}";
            writer.WriteValue(timespanFormatted);
        }

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            System.Diagnostics.Contracts.Contract.Requires(null != reader);

            TimeSpan.TryParseExact((string)reader.Value, _formatString, null, out TimeSpan parsedTimeSpan);
            return parsedTimeSpan;
        }
    }
}
