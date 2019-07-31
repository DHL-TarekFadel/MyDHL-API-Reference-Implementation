using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class ReferenceQuery
    {
        [Required]
        public int ShipperAccountNumber { get; set; }

        [ValidateObject]
        public ShipmentReferences ShipmentReferences { get; set; }

        [ValidateObject]
        public ShipmentDateRange ShipmentDateRange { get; set; }
    }
}
