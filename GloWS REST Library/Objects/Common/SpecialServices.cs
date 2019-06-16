using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Common {
    public class SpecialServices {
        [ValidateObject]
        [JsonProperty("Service")]
        public List<SpecialService> Service { get; set; }
    }

    public class SpecialService {
        /// <summary>
        /// Special service code (ex: II for non-documents insurance)
        /// </summary>
        [Required]
        [StringLength(2, MinimumLength = 2)]
        [JsonProperty("ServiceType")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Monetary value of service (e.g. Insured Value) – this is needed if you wish to get a quote on Insurance with your prospect shipment
        /// </summary>
        [JsonProperty("ServiceValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ServiceValue { get; set; }

        /// <summary>
        /// ISO 3 digit currency code is needed if you wish to get a quote on Insurance with your prospect shipment
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        [JsonProperty("CurrencyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// For future use
        /// </summary>
        [JsonIgnore]
        [StringLength(3, MinimumLength = 3)]
        [JsonProperty("PaymentCode")]
        public string PaymentCode { get; set; }

        /// <summary>
        /// For future use
        /// </summary>
        [JsonIgnore]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// For future use
        /// </summary>
        [JsonIgnore]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// For future use
        /// </summary>
        [JsonIgnore]
        [StringLength(50)]
        public string TextInstruction { get; set; }

        public SpecialService() { }

        public SpecialService(string code, decimal? serviceValue = null, string currencyCode = "")
        {
            this.ServiceType = code;
            if (null != serviceValue)
            {
                this.ServiceValue = serviceValue;
                this.CurrencyCode = currencyCode;
            }
        }
    }
}