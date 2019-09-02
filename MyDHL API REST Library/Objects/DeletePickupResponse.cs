using MyDHLAPI_REST_Library.Objects.Common.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects
{
    public class DeletePickupResponse
    {
        public DeleteResponse DeleteResponse { get; set; }

        [JsonIgnore]
        public List<Notification> Notifications => DeleteResponse.Notifications;
    }

    public class DeleteResponse
    {
        public Response Response { get; set; }

        [JsonProperty("Notification")]
        public List<Notification> Notifications { get; set; }
    }
}
