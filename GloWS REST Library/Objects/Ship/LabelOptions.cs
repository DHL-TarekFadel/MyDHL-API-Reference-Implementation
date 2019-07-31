using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class LabelOptions
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PrinterDPI? PrinterDPI { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? HideAccountInWaybillDocument { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? RequestWaybillDocument { get; set; }

        [Range(1, 2)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfWaybillDocumentCopies { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? RequestDHLCustomsInvoice { get; set; }

        [JsonProperty("DHLCustomsInvoiceLanguageCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ISO3DigitLanguageCodes? CustomsInvoiceLanguageCode { get; set; }

        [JsonProperty("DHLCustomsInvoiceType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.CustomsInvoiceType CustomsInvoiceType { get; set; } = Enums.CustomsInvoiceType.CommercialInvoice;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.YesNo? RequestShipmentReceipt { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CustomerLogo CustomerLogo { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CustomerBarcode CustomerBarcode { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DetachOptions DetachOptions { get; set; }

    }
}