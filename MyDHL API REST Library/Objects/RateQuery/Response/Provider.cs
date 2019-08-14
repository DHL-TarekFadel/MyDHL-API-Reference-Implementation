using System.Collections.Generic;
using MyDHLAPI_REST_Library.Objects.Common.Response;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response
{
    public class Provider {
        [JsonProperty("@code")]
        public string Code { get; set; }

        public List<Notification> Notification { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Service>))]
        public List<Service> Service { get; set; }
    }
}
