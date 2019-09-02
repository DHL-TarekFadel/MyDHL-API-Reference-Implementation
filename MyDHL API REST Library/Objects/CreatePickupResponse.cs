using MyDHLAPI_REST_Library.Objects.Common.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects
{
    public class CreatePickupResponse
    {
        public PickupResponse PickupResponse { get; set; }

        [JsonIgnore]
        public List<Notification> Notifications => PickupResponse.Notifications;

        [JsonIgnore]
        public string PickupRequestNumber => PickupResponse.PickupRequestNumber;


    }

    public class PickupResponse
    {
        [JsonProperty("Notification")]
        public List<Notification> Notifications { get; set; }

        [JsonProperty("DispatchConfirmationNumber")]
        public string PickupRequestNumber { get; set; }
    }
}
