using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;

namespace MyDHLAPI_REST_Library.Objects.RateQuery {
    public class Packages {

        [ValidateObject]
        public List<RequestedPackages> RequestedPackages { get; set; }
    }
}