using Newtonsoft.Json.Converters;

namespace MyDHLAPI_REST_Library.Objects.Plumbing {
    public class CustomJSONDateTimeConverter : IsoDateTimeConverter {
        public CustomJSONDateTimeConverter(string format) {
            DateTimeFormat = format;
        }
    }
}
