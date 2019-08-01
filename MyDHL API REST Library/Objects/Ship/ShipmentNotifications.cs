using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class ShipmentNotifications
    {
        [ValidateObject]
        [CollectionLength(5, 1)]
        [JsonProperty("ShipmentNotification")]
        public List<ShipmentNotification> ShipmentNotification { get; set; }
    }

    public class ShipmentNotification
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentNotificationMethods NotificationMethod = Enums.ShipmentNotificationMethods.EMail;

        /// <summary>
        /// EMail address of the party to receive email notification.
        /// </summary>
        [StringLength(250)]
        [JsonProperty("EmailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EMailAddress { get; set; }

        /// <summary>
        /// Additional message to be added to the body of the mail
        /// </summary>
        [StringLength(250)]
        [JsonProperty("BespokeMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string BespokeMessage { get; set; }

        /// <summary>
        /// Language Code used in the email content.
        /// </summary>
        [JsonProperty("LanguageCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentNotificationLanguages? NotificationLanguage { get; set; }

        /// <summary>
        /// Language country code based on the selected Notification Language (ex: English US vs. English GB)
        /// </summary>
        [JsonProperty("LanguageCountryCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ShipmentNotificationLanguageCountryCode? LanguageCountryCode { get; set; }
    }
}