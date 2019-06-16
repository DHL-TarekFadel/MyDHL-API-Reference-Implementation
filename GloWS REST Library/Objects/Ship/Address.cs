using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class AddressData
    {
        [ValidateObject]
        [JsonProperty("Contact")]
        public Contact Contact { get; set; } = new Contact();

        [ValidateObject]
        [JsonProperty("Address")]
        public Address Address { get; set; } = new Address();
    }

    public class Contact
    {
        /// <summary>
        /// A contact name of a person who will ship/receive the shipment.
        /// </summary>
        [Required]
        [StringLength(45)]
        [JsonProperty("PersonName")]
        public string PersonName { get; set; }

        [Required]
        [StringLength(35)]
        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(25)]
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [JsonProperty("EmailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EMailAddress { get; set; }

        [StringLength(25)]
        [JsonProperty("MobilePhoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string MobilePhoneNumber { get; set; }
    }

    public class Address
    {
        /// <summary>
        /// Address line 1 should contain street name and number of the address.
        /// </summary>
        [Required]
        [StringLength(35)]
        [JsonProperty("StreetLines")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Shipper street name should be sent as separate attribute if feasible.
        /// </summary>
        [StringLength(35)]
        [JsonProperty("StreetName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StreetName { get; set; }

        /// <summary>
        /// Shipper street number should be sent as separate attribute, if feasible.
        /// </summary>
        [StringLength(15)]
        [JsonProperty("StreetNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Additional address information.
        /// </summary>
        [StringLength(35)]
        [DefaultValue("")]
        [JsonProperty("StreetLines2", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Additional address information.
        /// </summary>
        [StringLength(35)]
        [DefaultValue("")]
        [JsonProperty("StreetLines3", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Name of the city the address is in
        /// </summary>
        [Required]
        [StringLength(35)]
        [JsonProperty("City")]
        public string CityName { get; set; }

        /// <summary>
        /// USA ONLY, 2 Letter state code (ex: Texas = TX)
        /// </summary>
        [StringLength(2)]
        [DefaultValue("")]
        [JsonProperty("StateOrProvinceCode", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string USStateCode { get; set; }

        [Required]
        [StringLength(12)]
        [JsonProperty("PostalCode")]
        public string PostalOrZipCode { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("RegistrationNumbers", NullValueHandling = NullValueHandling.Ignore)]
        public List<RegistrationNumber> RegistrationNumbers { get; set; }
    }

    public class RegistrationNumber
    {
        /// <summary>
        /// Registration Number (ex: VAT ID, TRN number, etc.)
        /// </summary>
        [Required]
        [StringLength(20)]
        [JsonProperty("Number")]
        public string Number { get; set; }

        /// <summary>
        /// Type of the registration number. At this moment only “VAT” is allowed
        /// </summary>
        [Required]
        [JsonProperty("NumberTypeCode", ItemConverterType = typeof(StringEnumConverter))]
        public Enums.NumberTypeCode NumberType { get; set; }

        /// <summary>
        /// ISO 2 character code of the country where the Registration Number has been issued by
        /// </summary>
        [Required]
        [StringLength(2, MinimumLength = 2)]
        [JsonProperty("NumberIssuerCountryCode")]
        public string NumberIssuerCountryCode { get; set; }

    }
}