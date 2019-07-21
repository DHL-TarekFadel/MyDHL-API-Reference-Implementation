using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
