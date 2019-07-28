using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using MyDHLAPI_REST_Library.Objects.Tracking;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects
{
    public class KnownTrackingResponse
    {
        [ValidateObject]
#pragma warning disable IDE1006 // Naming Styles
        public trackShipmentRequestResponse trackShipmentRequestResponse { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [JsonIgnore]
        public TrackingResponse ActualResponse => trackShipmentRequestResponse.trackingResponse.TrackingResponse;
    }

#pragma warning disable IDE1006 // Naming Styles
    public class trackShipmentRequestResponse
    {
        [ValidateObject]
        public trackingResponse trackingResponse { get; set; }
    }

    public class trackingResponse
#pragma warning restore IDE1006 // Naming Styles
    {
        [ValidateObject]
        public TrackingResponse TrackingResponse { get; set; }
    }

    public class TrackingResponse
    {
        [ValidateObject]
        public Response Response { get; set; }


        [ValidateObject]
        public AWBInfo AWBInfo { get; set; }
    }

    public class Response
    {
        [ValidateObject]
        public ServiceHeader ServiceHeader { get; set; }

        public override string ToString()
        {
            return $"ServiceHeader: {ServiceHeader}";
        }
    }
}
