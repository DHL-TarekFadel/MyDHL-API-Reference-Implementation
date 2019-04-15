using GloWS_Test_App.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Serialization;

namespace GloWS_Test_App
{
    public static class Common
    {
        public static string soapProductionBaseUrl = "https://wsbexpress.dhl.com/gbl";
        public static string soapSandpitBaseUrl = "https://wsbexpress.dhl.com/sndpt";
        public static string soapE2EBaseUrl = "https://wsbexpressuat.dhl.com/gbl";
        public static string restProductionBaseUrl = "https://wsbexpress.dhl.com/rest/gbl";
        public static string restSandpitBaseUrl = "https://wsbexpress.dhl.com/rest/sndpt";
        public static string restE2EBaseUrl = "https://wsbexpressuat.dhl.com/rest/gbl";

        public static GloWSEnvironment CurrentEnvironment = GloWSEnvironment.Sandpit;
        public static Dictionary<GloWSEnvironment, Dictionary<string, string>> Credentials = new Dictionary<GloWSEnvironment, Dictionary<string, string>>();
        public static string CurrentRestBaseUrl = restSandpitBaseUrl;
        public static string CurrentSoapBaseUrl = soapSandpitBaseUrl;

        public static Dictionary<string, string> CurrentCredentials = new Dictionary<string, string>();

        public static Defaults Defaults;

        /// <summary>
        /// Prepares the GloWS Auth using WSSE
        /// </summary>
        /// <returns>Tuple(EndpointAddress, BasicHttpBinding, username, password)</returns>
        public static Tuple<EndpointAddress, BindingElementCollection, string, string> PrepareGlowsAuth(string endpoint)
        {
            EndpointAddress soapEndpoint = new EndpointAddress(string.Format("{0}/{1}", CurrentSoapBaseUrl, endpoint));
            BasicHttpsBinding binding = new BasicHttpsBinding();
            binding.Security.Mode = BasicHttpsSecurityMode.TransportWithMessageCredential;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            BindingElementCollection elements = binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;

            return new Tuple<EndpointAddress, BindingElementCollection, string, string>(soapEndpoint, elements, CurrentCredentials["Username"], CurrentCredentials["Password"]);
        }

        public static string GetTempFilenameWithExtension(string staticFilenamePart, string extension)
        {
            string path = Path.GetTempPath();
            string tempFilename = $"{staticFilenamePart}.{Guid.NewGuid():N}.{extension}";
            return Path.Combine(path, tempFilename);
        }

        public static string XMLToString(Type type, object xmlObj)
        {
            XmlSerializer respXmlSerializer = new XmlSerializer(type);

            using (Utf8StringWriter textWriter = new Utf8StringWriter())
            {
                respXmlSerializer.Serialize(textWriter, xmlObj);
                return textWriter.ToString();
            }
        }

        #region "Default values methods"
        public static void ParseDefaultsJSON(string jsonInput)
        {
            Defaults = JsonConvert.DeserializeObject<Defaults>(jsonInput);
        }

        public static void ApplyDefault(ref System.Windows.Forms.ComboBox comboBox, object defaultValue, object backupValue = null)
        {
            if (null == defaultValue)
            {
                comboBox.SelectedItem = backupValue;
            }
            else
            {
                comboBox.SelectedItem = defaultValue;
            }
        }

        public static void ApplyDefault(ref System.Windows.Forms.TextBox textBox, string defaultValue, string backupValue = "")
        {
            textBox.Text = (string.IsNullOrEmpty(defaultValue) ? backupValue : defaultValue);
        }

        public static void ApplyDefault(ref System.Windows.Forms.TextBox textBox, decimal? defaultValue, decimal backupValue = 0.5M)
        {
            textBox.Text = (null == defaultValue ? $"{backupValue:0.00}" : $"{defaultValue:0.00}");
        }

        public static void ApplyDefault(ref System.Windows.Forms.TextBox textBox, int? defaultValue, int backupValue = 1)
        {
            textBox.Text = (null == defaultValue ? $"{backupValue}" : $"{defaultValue}");
        }

        public static void ApplyDefault(ref System.Windows.Forms.NumericUpDown textBox, decimal? defaultValue, decimal backupValue = 0M)
        {
            textBox.Value = (defaultValue ?? backupValue);
        }
        #endregion

        public enum GloWSEnvironment
        {
            Sandpit
            , Production
            , E2E
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        // Use UTF8 encoding but write no BOM to the wire
        public override System.Text.Encoding Encoding => new System.Text.UTF8Encoding(false);
    }
}
