using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDHLAPI_REST_Library.Objects.Ship.Response
{
    public class AdditionalInformation
    {
        public string BillingCode { get; set; }

        public decimal? VolumetricWeight { get; set; }

        public DateTime? CutOffTime { get; set; }

        public string DHLRoutingCode { get; set; }

        public string DHLRoutingDataID { get; set; }

        public string ServiceContentCode { get; set; }

        public string DeliveryDateCode { get; set; }

        public string DeliveryTimeCode { get; set; }

        [JsonProperty("ServiceHandlingFeatureCodes")]
        public List<HandlingAndFeatureCode> HandlingAndFeatureCodes { get; set; }

        [JsonProperty("OriginServiceArea")]
        public ServiceArea Origin { get; set; }

        [JsonProperty("DestinationServiceArea")]
        public ServiceArea Destination { get; set; }

        [JsonProperty("Ship")]
        public AddressData AddressData { get; set; }
    }
}
