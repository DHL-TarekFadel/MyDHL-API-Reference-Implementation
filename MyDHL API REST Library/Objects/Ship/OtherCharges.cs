using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class OtherCharges
    {
        [ValidateObject]
        [CollectionLength(3, 1)]
        public List<OtherCharge> OtherCharge { get; set; }
    }
}