using MyDHLAPI_REST_Library.Objects.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ODD
    {
        [Required]
        [JsonProperty("DeliveryOption", ItemConverterType = typeof(StringEnumConverter))]
        public Enums.ODDOption DeliveryOption { get; set; }

        /// <summary>
        /// Mandatory if the above delivery option is SX and should advise DHL where exactly to leave the shipment (ie.front door etc)
        /// </summary>
        [StringLength(15)]
        [JsonProperty("Location")]
        public string Location { get; set; }

        /// <summary>
        /// Additional information that is useful for the DHL Express courier
        /// </summary>
        [StringLength(10)]
        [JsonProperty("Instructions")]
        public string InstructionsToCourier { get; set; }

        /// <summary>
        /// Entry code to gain access to an apartment complex or gate
        /// </summary>
        [StringLength(10)]
        [JsonProperty("GateCode")]
        public string GateCode { get; set; }

        /// <summary>
        /// Mandatory if the delivery option is SW
        /// </summary>
        [JsonProperty("LWNTypeCode", ItemConverterType = typeof(StringEnumConverter))]
        public Enums.ODDLeaveWithType? LeaveWith { get; set; }

        /// <summary>
        /// Name of the neighbour who is authorized to receive the shipment. Mandatory if the delivery option is SW and the LeaveWith value is "Neighbour."
        /// </summary>
        [StringLength(20)]
        [JsonProperty("NeighbourName")]
        public string NeighbourName { get; set; }

        /// <summary>
        /// House number of the neighbour who is authorized to receive the shipment. Mandatory if the delivery option is SW and the LeaveWith value is "Neighbour."
        /// </summary>
        [StringLength(20)]
        [JsonProperty("NeighbourHouseNumber")]
        public string NeighbourHouseNumber { get; set; }

        /// <summary>
        /// Mandatory if delivery option is SX or SW – this is the person that this authorised to sign and receive the DHL Express shipment
        /// </summary>
        [StringLength(20)]
        [JsonProperty("AuthorizerName")]
        public string AuthorizerName { get; set; }

        /// <summary>
        /// Mandatory if delivery option is TV – this is the unique DHL Express Service point location ID of where the parcel should be delieverd (please contact your local DHL Express Account Manager to obtain the list of the servicepoint IDs)
        /// </summary>
        [StringLength(6)]
        [JsonProperty("SelectedServicePointID")]
        public string SelectedServicePointId { get; set; }

        [StringLength(29)]
        [JsonIgnore]
        public System.DateTime RequestedDeliveryDate { get; set; }
    }
}