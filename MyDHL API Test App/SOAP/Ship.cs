using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyDHLAPI_Test_App.com.dhl.wsbexpress.shipment;
using System.IO;
using System.ServiceModel.Channels;

namespace MyDHLAPI_Test_App.SOAP
{
    public partial class Ship : Form
    {
        private List<string> _productCodes = new List<string> { "", "0", "1", "2", "3", "4", "5", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        //private string GloWS_Request;
        //private string GloWS_Response;

        //private bool _logoAvailable;
        private byte[] _logoData;
        //private bool _invoiceAvailable;
        private byte[] _invoiceData;

        private List<string> _generatedTempFiles = new List<string>();

        //private string[] doxProducts = {}

        public Ship()
        {
            InitializeComponent();
        }

        private void Ship_Load(object sender, EventArgs e)
        {
            cmbProductCode.DataSource = _productCodes;
            cmbShipmentDimsUOM.DataSource = new[] { "", "CM", "IN" };
            cmbShipmentWeightUOM.DataSource = new[] { "", "KG", "LB" };

            cmbProductCode.SelectedItem = "P";
            cmbShipmentDimsUOM.SelectedItem = "CM";
            cmbShipmentWeightUOM.SelectedItem = "KG";
        }

        private void Ship_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            try
            {
                foreach (string tempFilename in _generatedTempFiles)
                {
                    File.Delete(tempFilename);
                }
            }
            catch (IOException)
            {
                if (DialogResult.No == MessageBox.Show("Cannot delete temporary AWB file(s). By closing this form, no automatic cleanup will happen. Do you still want to exit?"
                                                        , "Files still open"
                                                        , MessageBoxButtons.YesNo
                                                        , MessageBoxIcon.Warning
                                                        , MessageBoxDefaultButton.Button2))
                {
                    e.Cancel = true;
                }
            }
        }

        private void BtnShip_Click(object sender, EventArgs e)
        {
            ClearInputErrors();

            // Validate all our inputs
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fix the issues on the inputs marked in red.");
                return;
            }

            // All validation done, send the data to GloWS.
#pragma warning disable IDE0017 // Simplify object initialization
//            try
//            {
//                this.Enabled = false;

//                // Reset AWB link label
//                llblAWB.Tag = null;
//                llblAWB.LinkBehavior = LinkBehavior.NeverUnderline;
//                llblAWB.ForeColor = Color.Black;
//                llblAWB.Font = new Font(llblAWB.Font, FontStyle.Regular);

//                // Determine if this is a dox or non-dox shipment
//                bool isDox = !(new[] { "3", "4", "8", "E", "F", "H", "J", "M", "P", "Q", "V", "Y" }).Contains(cmbProductCode.SelectedValue.ToString());
//                bool isDomestic = "N" == cmbProductCode.Text;

//                createShipmentRequestRequest reqData = new createShipmentRequestRequest();
                
//                reqData.RequestedShipment = new docTypeRef_RequestedShipmentType();
//                reqData.MessageId = Guid.NewGuid().ToString("N");
//#pragma warning restore IDE0017 // Simplify object initialization

//                docTypeRef_ShipmentInfoType shipmentInfo = new docTypeRef_ShipmentInfoType();
//                if (cbxShipmentRequestPickup.Checked)
//                {
//                    shipmentInfo.DropOffType = DropOffType.REQUEST_COURIER;
//                }
//                else
//                {
//                    shipmentInfo.DropOffType = DropOffType.REGULAR_PICKUP;
//                }

//                string[] pltCountries = new string[] { "AE", "SA", "US"};
//                bool isPLT = false;

//                /*** PLT ***/
//                if (!isDomestic
//                    && !isDox
//                    && _invoiceAvailable
//                    && (pltCountries.Contains(txtShipperCountry.Text)
//                        || pltCountries.Contains(txtConsigneeCountry.Text))
//                    )
//                {
//                    shipmentInfo.PaperlessTradeEnabled = true;
//                    shipmentInfo.PaperlessTradeEnabledSpecified = true;
//                    shipmentInfo.PaperlessTradeImage = _invoiceData;
//                    isPLT = true;
//                }

//                shipmentInfo.ServiceType = cmbProductCode.SelectedValue.ToString();
                
//                // SU = Standard (american) Units (LB, IN); SI = Standard International (KG, CM)
//                if ("KG" == cmbShipmentWeightUOM.SelectedValue.ToString())
//                {
//                    shipmentInfo.UnitOfMeasurement = UnitOfMeasurement.SI;
//                }
//                else
//                {
//                    shipmentInfo.UnitOfMeasurement = UnitOfMeasurement.SU;
//                }

//                // If the billing element is defined (it should be used anyway) then there is no need for the
//                // generic shipmentInfo.Account element to be populated.
//                //shipmentInfo.Account = txtShipperAccountNumber.Text;
//                shipmentInfo.Billing = new Billing()
//                {
//                    BillingAccountNumber = txtShipperAccountNumber.Text
//                    , ShipperAccountNumber = txtShipperAccountNumber.Text
//                    , ShippingPaymentType = ShipmentPaymentType.S
//                };

//                if (!isDomestic && !isDox)
//                {
//                    // We have a non-dox shipment
//                    shipmentInfo.Currency = txtShipmentDeclaredValueCurrency.Text;
//                }

//                shipmentInfo.LabelType = LabelType.PDF;
//                shipmentInfo.LabelTypeSpecified = true;

//                shipmentInfo.PackagesCount = "1";
                
//                reqData.RequestedShipment.ShipmentInfo = shipmentInfo;

//                DateTime timestamp;

//                if (DateTime.Now.TimeOfDay > new TimeSpan(18, 00, 00))
//                {
//                    timestamp = DateTime.Now.AddDays(1);
//                    timestamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 10, 0, 0);
//                }
//                else
//                {
//                    timestamp = DateTime.Now.AddMinutes(10);
//                }
                
//                reqData.RequestedShipment.ShipTimestamp = $"{timestamp:s} GMT{timestamp:zzz}";

//                if (!IsBlank(txtDutyAccountNumber))
//                {
//                    reqData.RequestedShipment.PaymentInfo = PaymentInfo.DDP;
//                }
//                else
//                {
//                    reqData.RequestedShipment.PaymentInfo = PaymentInfo.DDU;
//                }

//                docTypeRef_InternationDetailType internationalDetail = new docTypeRef_InternationDetailType();

//                if (!isDox && !isDomestic)
//                {
//                    internationalDetail.Content = Content.NON_DOCUMENTS;
//                    docTypeRef_CommoditiesType commodities = new docTypeRef_CommoditiesType();
//                    commodities.CustomsValue = 20M;
//                    commodities.CustomsValueSpecified = true;
//                    commodities.CountryOfManufacture = "AE";
//                    commodities.Description = "Test Commoditiy";
//                    commodities.NumberOfPieces = "2";
//                    commodities.UnitPrice = "10";
//                    internationalDetail.Commodities = commodities;
//                }
//                else
//                {
//                    internationalDetail.Content = Content.DOCUMENTS;
//                }
//                internationalDetail.ContentSpecified = true;

//                reqData.RequestedShipment.InternationalDetail = internationalDetail;

//                reqData.RequestedShipment.Ship = new docTypeRef_ShipType();

//                /*** SHIPPER ***/

//                docTypeRef_ContactInfoType shipper = new docTypeRef_ContactInfoType();

//                docTypeRef_ContactType shipperContact = new docTypeRef_ContactType();
//                if (!IsBlank(txtShipperCompany))
//                {
//                    shipperContact.CompanyName = txtShipperCompany.Text;
//                }
//                else
//                {
//                    shipperContact.CompanyName = txtShipperName.Text;
//                }
//                shipperContact.PersonName = txtShipperName.Text;
//                shipperContact.EmailAddress = txtShipperEMailAddress.Text;
//                shipperContact.PhoneNumber = txtShipperMobileNumber.Text;

//                shipper.Contact = shipperContact;

//                docTypeRef_AddressType shipperAddress = new docTypeRef_AddressType();
//                shipperAddress.StreetLines = txtShipperAddress1.Text;
//                shipperAddress.StreetLines2 = (string.IsNullOrWhiteSpace(txtShipperAddress2.Text) ? "." : txtShipperAddress2.Text);
//                shipperAddress.StreetLines3 = (string.IsNullOrWhiteSpace(txtShipperAddress3.Text) ? "." : txtShipperAddress3.Text);
//                shipperAddress.City = txtShipperCity.Text;
//                shipperAddress.StateOrProvinceCode = txtShipperState.Text;
//                shipperAddress.CountryCode = txtShipperCountry.Text;
//                shipperAddress.PostalCode = txtShipperPostalCode.Text;
//                shipper.Address = shipperAddress;

//                reqData.RequestedShipment.Ship.Shipper = shipper;

//                /*** CONSIGNEE ***/
//                docTypeRef_ContactInfoType consignee = new docTypeRef_ContactInfoType();

//                docTypeRef_ContactType consigneeContact = new docTypeRef_ContactType();
//                if (!IsBlank(txtConsigneeCompany))
//                {
//                    consigneeContact.CompanyName = txtConsigneeCompany.Text;
//                }
//                else
//                {
//                    consigneeContact.CompanyName = txtConsigneeName.Text;
//                }
//                consigneeContact.PersonName = txtConsigneeName.Text;
//                consigneeContact.EmailAddress = txtConsigneeEMailAddress.Text;
//                consigneeContact.PhoneNumber = txtConsigneeMobileNumber.Text;

//                consignee.Contact = consigneeContact;

//                docTypeRef_AddressType consigneeAddress = new docTypeRef_AddressType();
//                consigneeAddress.StreetLines = txtConsigneeAddress1.Text;
//                consigneeAddress.StreetLines2 = (string.IsNullOrWhiteSpace(txtConsigneeAddress2.Text) ? "." : txtConsigneeAddress2.Text);
//                consigneeAddress.StreetLines3 = (string.IsNullOrWhiteSpace(txtConsigneeAddress3.Text) ? "." : txtConsigneeAddress3.Text);
//                consigneeAddress.City = txtConsigneeCity.Text;
//                consigneeAddress.StateOrProvinceCode = txtConsigneeState.Text;
//                consigneeAddress.CountryCode = txtConsigneeCountry.Text;
//                consigneeAddress.PostalCode = txtConsigneePostalCode.Text;
//                consignee.Address = consigneeAddress;

//                reqData.RequestedShipment.Ship.Recipient = consignee;

//                /*** PICKUP ***/
//                if (cbxShipmentRequestPickup.Checked)
//                {
//                    reqData.RequestedShipment.Ship.Pickup = shipper;
//                }

//                /*** PIECES ***/
//                reqData.RequestedShipment.Packages = new docTypeRef_PackagesType();

//                List<docTypeRef_RequestedPackagesType> requestedPackages = new List<docTypeRef_RequestedPackagesType>();

//                docTypeRef_RequestedPackagesType singlePackage = new docTypeRef_RequestedPackagesType();
//                singlePackage.number = "1";
//                singlePackage.Weight = decimal.Parse($"{txtShipmentWeight.Text}");

//                int height = GetDimension(ref txtShipmentHeight);
//                int width = GetDimension(ref txtShipmentWidth);
//                int depth = GetDimension(ref txtShipmentDepth);

//                if (height > 0
//                    && width > 0
//                    && depth > 0)
//                {
//                    // Keep the divisor at 5000.0, this forces .NET to treate the result as a float and not an integer.
//                    singlePackage.Dimensions = new docTypeRef_DimensionsType
//                    {
//                        Height = decimal.Parse($"{height}"),
//                        Width = decimal.Parse($"{width}"),
//                        Length = decimal.Parse($"{depth}")
//                    };
//                }

//                singlePackage.CustomerReferences = $"{DateTime.Now.Ticks}";

//                requestedPackages.Add(singlePackage);

//                reqData.RequestedShipment.Packages.RequestedPackages = requestedPackages.ToArray();
                
//                /*** SPECIAL SEVICES ***/
//                List<Service> specialServices = new List<Service>();
//                if (isPLT)
//                {
//                    specialServices.Add(new Service()
//                    {
//                        ServiceType = "WY"
//                    });
//                }
//                reqData.RequestedShipment.ShipmentInfo.SpecialServices = specialServices.ToArray();

//                if (!reqData.RequestedShipment.ShipmentInfo.SpecialServices.Any())
//                {
//                    reqData.RequestedShipment.ShipmentInfo.SpecialServices = null;
//                }

//                /*** GENERATE SHIPMENT ***/
//                GloWS_Request = Common.XMLToString(reqData.GetType(), reqData);

//                var glowsAuthData = Common.PrepareGlowsAuth("expressRateBook");

//                gblExpressRateBookClient client = new gblExpressRateBookClient(new CustomBinding(glowsAuthData.Item2), glowsAuthData.Item1);
//                client.ClientCredentials.UserName.UserName = glowsAuthData.Item3;
//                client.ClientCredentials.UserName.Password = glowsAuthData.Item4;

//                docTypeRef_NotificationType2[] resp;
//                docTypeRef_PackageResultType[] packages;
//                docTypeRef_LabelImageType[] labels;
//                string shipmentIdentificationNumber;
//                string dispatchConfirmationNumber;

//                try
//                {
//                    resp = client.createShipmentRequest(reqData.MessageId
//                                                        , reqData.ClientDetail
//                                                        , reqData.RequestedShipment
//                                                        , out packages
//                                                        , out labels
//                                                        , out shipmentIdentificationNumber
//                                                        , out dispatchConfirmationNumber);
//                }
//                catch (Exception ex)
//                {
//                    var text = ex.Message;
//                    txtResultAWB.Text = "ERROR!";
//                    return;
//                }

//                if (null == resp || !resp.Any())
//                {
//                    MessageBox.Show("There was an error in generating the shipment.");
//                    return;
//                }

//                GloWS_Response = Common.XMLToString(resp.GetType(), resp);

//                // Display our results

//                if (!string.IsNullOrEmpty(shipmentIdentificationNumber))
//                {
//                    txtResultAWB.Text = shipmentIdentificationNumber;
//                }
//                else
//                {
//                    txtResultAWB.Text = string.Empty;
//                }

//                if (null != packages)
//                {
//                    string prefix = string.Empty;
//                    string pieces = string.Empty;

//                    foreach (docTypeRef_PackageResultType package in packages)
//                    {
//                        pieces += $"{prefix}{package.TrackingNumber}";
//                        prefix = Environment.NewLine;
//                    }

//                    txtResultPieces.Text = pieces;
//                }
//                else
//                {
//                    txtResultPieces.Text = string.Empty;
//                }

//                if (!string.IsNullOrEmpty(dispatchConfirmationNumber))
//                {
//                    txtResultBookingReferenceNumber.Text = dispatchConfirmationNumber;
//                }
//                else
//                {
//                    txtResultBookingReferenceNumber.Text = string.Empty;
//                }

//                if (labels.Any())
//                {
//                    int i = 0;
//                    // Prepare our files for viewing
//                    foreach (var label in labels)
//                    {
//                        var tempFilename = Common.GetTempFilenameWithExtension(txtResultAWB.Text, label.LabelImageFormat);
//                        File.WriteAllBytes(tempFilename, label.GraphicImage);
//                        _generatedTempFiles.Add(tempFilename);

//                        if (0 == i++)
//                        {
//                            llblAWB.Tag = tempFilename;
//                            llblAWB.LinkBehavior = LinkBehavior.AlwaysUnderline;
//                            llblAWB.ForeColor = Color.White;
//                            llblAWB.Font = new Font(llblAWB.Font, FontStyle.Bold);
//                        }
//                    }                    
//                }
                
//            }
//            finally
//            {
//                this.Enabled = true;
//            }
        }

        private void ClearInputErrors()
        {

            /*** SHIPPER ***/
            ClearError(ref txtShipperName);
            ClearError(ref txtShipperMobileNumber);
            ClearError(ref txtShipperAddress1);
            ClearError(ref txtShipperCountry);
            ClearError(ref txtShipperCity);
            ClearError(ref txtShipperPostalCode);

            /*** CONSIGNEE ***/
            ClearError(ref txtConsigneeName);
            ClearError(ref txtConsigneeMobileNumber);
            ClearError(ref txtConsigneeAddress1);
            ClearError(ref txtConsigneeCountry);
            ClearError(ref txtConsigneeCity);
            ClearError(ref txtConsigneePostalCode);

            /*** SHIPMENT ***/
            ClearError(ref txtShipmentContents);
            ClearError(ref txtShipmentWeight);
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            /*** SHIPPER ***/
            if (IsBlank(txtShipperName))
            {
                IndicateError(ref txtShipperName);
                isValid = false;
            }
            if (IsBlank(txtShipperMobileNumber)) {
                IndicateError(ref txtShipperMobileNumber);
                isValid = false;
            }
            if (IsBlank(txtShipperAddress1))
            {
                IndicateError(ref txtShipperAddress1);
                isValid = false;
            }
            if (IsBlank(txtShipperCountry))
            {
                IndicateError(ref txtShipperCountry);
                isValid = false;
            }
            if (IsBlank(txtShipperCity) && IsBlank(txtShipperPostalCode))
            {
                IndicateError(ref txtShipperCity, "Either city or postal code must have a value");
                IndicateError(ref txtShipperPostalCode, "Either city or postal code must have a value");
                isValid = false;
            }
            if (!IsBlank(txtShipperState) && IsBlank(txtShipperPostalCode)) {
                IndicateError(ref txtShipperPostalCode, "Postal/Zip Code must have a value for country US");
                isValid = false;
            }

            /*** CONSIGNEE ***/
            if (IsBlank(txtConsigneeName))
            {
                IndicateError(ref txtConsigneeName);
                isValid = false;
            }
            if (IsBlank(txtConsigneeMobileNumber))
            {
                IndicateError(ref txtConsigneeMobileNumber);
                isValid = false;
            }
            if (IsBlank(txtConsigneeAddress1))
            {
                IndicateError(ref txtConsigneeAddress1);
                isValid = false;
            }
            if (IsBlank(txtConsigneeCountry))
            {
                IndicateError(ref txtConsigneeCountry);
                isValid = false;
            }
            if (IsBlank(txtConsigneeCity) && IsBlank(txtConsigneePostalCode))
            {
                IndicateError(ref txtConsigneeCity, "Either city or postal code must have a value");
                IndicateError(ref txtConsigneePostalCode, "Either city or postal code must have a value");
                isValid = false;
            }
            if (!IsBlank(txtConsigneeState) && IsBlank(txtConsigneePostalCode))
            {
                IndicateError(ref txtConsigneePostalCode, "Postal/Zip Code must have a value for country US");
                isValid = false;
            }

            /*** SHIPMENT ***/
            if (IsBlank(txtShipmentContents))
            {
                IndicateError(ref txtShipmentContents);
                isValid = false;
            }
            if (IsBlank(txtShipmentWeight))
            {
                IndicateError(ref txtShipmentWeight);
                isValid = false;
            }

            return isValid;
        }

        private bool IsBlank(TextBox tbx)
        {
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                return true;
            }
            return false;
        }

        private void ClearError(ref TextBox tbx)
        {
            tbx.ForeColor = Color.Black;
            tbx.BackColor = Color.White;
            ToolTip1.SetToolTip(tbx, string.Empty);
        }

        private void IndicateError(ref TextBox tbx, string msg = "Field is required.")
        {
            tbx.ForeColor = Color.White;
            tbx.BackColor = Color.Red;
            ToolTip1.SetToolTip(tbx, msg);
        }

        private void CalculateDImWeight(object sender, EventArgs e)
        {
            int height = GetDimension(ref txtShipmentHeight);
            int width = GetDimension(ref txtShipmentWidth);
            int depth = GetDimension(ref txtShipmentDepth);

            if (height > 0
                && width > 0
                && depth > 0)
            {
                // Keep the divisor at 5000.0, this forces .NET to treate the result as a float and not an integer.
                txtShipmentDimWeight.Text = $"{(height * width * depth) / 5000.0}";
            }
            else
            {
                txtShipmentDimWeight.Text = string.Empty;
            }
        }

        private int GetDimension(ref TextBox tbx)
        {
            ClearError(ref tbx);

            if (IsBlank(tbx))
            {
                return -1;
            }
            if (!Regex.IsMatch(tbx.Text, "^\\d+$"))
            {
                IndicateError(ref tbx, "Please enter a valid whole number.");
                return 0;
            }
            try
            {
                int dim = int.Parse(tbx.Text);
                if (0 >= dim)
                {
                    IndicateError(ref tbx, "Please enter a non-zero positive whole number.");
                    return 0;
                }
                return dim;
            }
            catch
            {
                return 0;
            }
        }

        private void BtnViewRequest_Click(object sender, EventArgs e)
        {
            //XMLViewer frm = new XMLViewer(GloWS_Request);
            //frm.ShowDialog();
        }

        private void BtnViewResponse_Click(object sender, EventArgs e)
        {
            //XMLViewer frm = new XMLViewer(GloWS_Response);
            //frm.ShowDialog();
        }

        private void LlblAWB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(llblAWB.Tag.ToString()))
            {
                System.Diagnostics.Process.Start(llblAWB.Tag.ToString());
            }
        }

        private void BtnUploadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                _logoData = File.ReadAllBytes(dlg.FileName);
                //_logoAvailable = true;
                lblLogoUploaded.Text = "Loaded!";
                lblLogoUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Bold);
            }
        }

        private void BtnUploadInvoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png|PDF Files|*.pdf";
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                _invoiceData = File.ReadAllBytes(dlg.FileName);
                //_invoiceAvailable = true;
                lblInvoiceUploaded.Text = "Loaded!";
                lblInvoiceUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Bold);
            }
        }

        private void CmbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbProductCode.SelectedValue)
            {
                case "1":
                case "2":
                case "5":
                case "7":
                case "9":
                case "B":
                case "C":
                case "D":
                case "G":
                case "I":
                case "K":
                case "L":
                case "N":
                case "O":
                case "R":
                case "S":
                case "T":
                case "U":
                case "W":
                case "X":
                    txtShipmentDeclaredValue.Enabled = false;
                    txtShipmentDeclaredValueCurrency.Enabled = false;
                    break;
                default:
                    txtShipmentDeclaredValue.Enabled = true;
                    txtShipmentDeclaredValueCurrency.Enabled = true;
                    break;
            }
        }
    }
}
