using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters {
    public class CustomJSONDateTimeConverter : IsoDateTimeConverter {
        public CustomJSONDateTimeConverter(string format) {
            DateTimeFormat = format;
        }
    }
}
