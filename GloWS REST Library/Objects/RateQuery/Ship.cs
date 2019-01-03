using GloWS_REST_Library.Objects.Plumbing.Attributes;

namespace GloWS_REST_Library.Objects.RateQuery {
    public class Ship {
        /// <summary>
        /// Shipper's address information
        /// </summary>
        [ValidateObject]
        public Address Shipper { get; set; }

        /// <summary>
        /// Recipient/Consignee address information
        /// </summary>
        [ValidateObject]
        public Address Recipient { get; set; }
    }
}