using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MyDHLAPI_REST_Library.Objects.Common.Response {
    public class Notification {
        /// <summary>
        /// Error > 0 or Success Code = 0
        /// </summary>
        [JsonProperty("@code")]
        public string Code { get; set; }

        /// <summary>
        /// Response Message
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }

        public static bool HasSuccessCode (List<Notification> notifications)
        {
            return notifications.Any(n => n.Code == "0");
        }

        public static string GetAllNotifications (List<Notification> notifications, string separator)
        {
            if (null == notifications)
            {
                return string.Empty;
            }

            string retval = string.Empty;
            string prefix = string.Empty;
            foreach (Notification notification in notifications)
            {
                if (!string.IsNullOrWhiteSpace(notification.Message))
                {
                    retval += $"{prefix}({notification.Code}) {notification.Message}";
                    prefix = separator;
                }
            }

            return retval;
        }
    }
}