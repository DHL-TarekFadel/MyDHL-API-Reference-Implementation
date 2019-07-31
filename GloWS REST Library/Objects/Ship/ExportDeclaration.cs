using System;
using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Plumbing.JSON_Converters;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ExportDeclaration
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationPort { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExporterCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExporterID { get; set; }

        [StringLength(16)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExportLicense { get; set; }

        [StringLength(30)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExportReason { get; set; }

        [StringLength(16)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ImportLicense { get; set; }

        [JsonConverter(typeof(CustomJSONDateTimeConverter), "yyyy-MM-dd")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public string InvoiceNumber { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PackageMarks { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PayerGSTVAT { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientReference { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TermsOfPayment { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Remarks Remarks { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OtherCharges OtherCharges { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InvoiceSignatureDetails InvoiceSignatureDetails { get; set; }

        [ValidateObject]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public InvoiceDeclarationTexts InvoiceDeclarationTexts { get; set; }

        [ValidateObject]
        public ExportLineItems ExportLineItems { get; set; }
    }
}