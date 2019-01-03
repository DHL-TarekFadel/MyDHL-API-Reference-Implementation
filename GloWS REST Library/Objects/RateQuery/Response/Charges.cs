using System.Collections.Generic;
using GloWS_REST_Library.Objects.Plumbing;
using GloWS_REST_Library.Objects.Tracking;
using Newtonsoft.Json;

namespace GloWS_REST_Library.Objects.RateQuery.Response {
    public class Charges {
        public string Currency { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Charge>))]
        public List<Charge> Charge { get; set; } = new List<Charge>();

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Currency: {Currency} | # of Charges: {Charge.Count}";
        }
    }
}