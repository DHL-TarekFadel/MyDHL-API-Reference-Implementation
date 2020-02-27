using MyDHLAPI_REST_Library.Objects.Pickup;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System;

namespace MyDHLAPI_REST_Library.Objects
{
    public class CreatePickupRequest
    {

        [ValidateObject]
        public PickUpRequest PickUpRequest { get; set; }
    }

    public class PickUpRequest
    {
        public string MessageId { get; protected set; }

        [ValidateObject]
        public PickUpShipment PickUpShipment { get; set; }

        public PickUpRequest()
        {
            this.MessageId = Guid.NewGuid().ToString("N", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
