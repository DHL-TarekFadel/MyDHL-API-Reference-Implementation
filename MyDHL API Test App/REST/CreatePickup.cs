using MyDHLAPI_REST_Library;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.DataAnnotations;
using MyDHLAPI_REST_Library.Objects.Pickup;
using MyDHLAPI_REST_Library.Objects.Common.Response;

namespace MyDHLAPI_Test_App.REST
{
    public partial class CreatePickup : Form
    {
        private readonly List<string> _productCodes = new List<string> { "", "0", "1", "2", "3", "4", "5", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string MyDHLAPI_Request = string.Empty;
        private string MyDHLAPI_Response = string.Empty;

        private readonly List<string> _generatedTempFiles = new List<string>();

        private readonly Dictionary<string, Dictionary<string, TextBox>> _addressInputs = new Dictionary<string, Dictionary<string, TextBox>>();

        public CreatePickup()
        {
            InitializeComponent();

            Dictionary<string, TextBox> shipperInputs = new Dictionary<string, TextBox>
            {
                { "Company", txtShipperCompany },
                { "Person", txtShipperName },
                { "EMail", txtShipperEMailAddress },
                { "Mobile", txtShipperMobileNumber },
                { "Address1", txtShipperAddress1 },
                { "Address2", txtShipperAddress2 },
                { "Address3", txtShipperAddress3 },
                { "Country", txtShipperCountry },
                { "State", txtShipperState },
                { "City", txtShipperCity },
                { "PostalCode", txtShipperPostalCode }
            };

            Dictionary<string, TextBox> pickupInputs = new Dictionary<string, TextBox>
            {
                { "Company", txtPickupCompany },
                { "Person", txtPickupName },
                { "EMail", txtPickupEMailAddress },
                { "Mobile", txtPickupMobileNumber },
                { "Address1", txtPickupAddress1 },
                { "Address2", txtPickupAddress2 },
                { "Address3", txtPickupAddress3 },
                { "Country", txtPickupCountry },
                { "State", txtPickupState },
                { "City", txtPickupCity },
                { "PostalCode", txtPickupPostalCode }
            };

            Dictionary<string, TextBox> receiverInputs = new Dictionary<string, TextBox>
            {
                { "Company", txtConsigneeCompany },
                { "Person", txtConsigneeName },
                { "EMail", txtConsigneeEMailAddress },
                { "Mobile", txtConsigneeMobileNumber },
                { "Address1", txtConsigneeAddress1 },
                { "Address2", txtConsigneeAddress2 },
                { "Address3", txtConsigneeAddress3 },
                { "Country", txtConsigneeCountry },
                { "State", txtConsigneeState },
                { "City", txtConsigneeCity },
                { "PostalCode", txtConsigneePostalCode }
            };

            Dictionary<string, TextBox> requestorInputs = new Dictionary<string, TextBox>
            {
                { "Company", txtRequestorCompany },
                { "Person", txtRequestorName },
                { "EMail", txtRequestorEMailAddress },
                { "Mobile", txtRequestorMobileNumber },
                { "Address1", txtRequestorAddress1 },
                { "Address2", txtRequestorAddress2 },
                { "Address3", txtRequestorAddress3 },
                { "Country", txtRequestorCountry },
                { "State", txtRequestorState },
                { "City", txtRequestorCity },
                { "PostalCode", txtRequestorPostalCode }
            };

            _addressInputs.Add("Shipper", shipperInputs);
            _addressInputs.Add("Pickup", pickupInputs);
            _addressInputs.Add("Receiver", receiverInputs);
            _addressInputs.Add("Requestor", requestorInputs);
        }

        private void CreatePickup_Load(object sender, EventArgs e)
        {
            cmbProductCode.DataSource = _productCodes;
            cmbShipmentDimsUOM.DataSource = new[] { "", "CM", "IN" };
            cmbShipmentWeightUOM.DataSource = new[] { "", "KG", "LB" };

            if (null != Common.Defaults)
            {
                Common.ApplyDefault(ref txtShipperAccountNumber, Common.Defaults.ShipperAccountNumber);
                Common.ApplyDefault(ref txtShipmentDeclaredValue, Common.Defaults.DeclaredValue, 0M);
                Common.ApplyDefault(ref txtShipmentDeclaredValueCurrency, Common.Defaults.DeclaredCurrency);
                Common.ApplyDefault(ref txtShipmentContents, Common.Defaults.ShipmentContents);
                Common.ApplyDefault(ref txtShipmentReference, Common.Defaults.ShipmentReference);

                if (null != Common.Defaults.From)
                {
                    var from = Common.Defaults.From;
                    Common.ApplyDefault(ref txtShipperCompany, from.CompanyName);
                    Common.ApplyDefault(ref txtShipperName, from.PersonName);
                    Common.ApplyDefault(ref txtShipperAddress1, from.Address1);
                    Common.ApplyDefault(ref txtShipperAddress2, from.Address2);
                    Common.ApplyDefault(ref txtShipperAddress3, from.Address3);
                    Common.ApplyDefault(ref txtShipperCity, from.City);
                    Common.ApplyDefault(ref txtShipperState, from.USState);
                    Common.ApplyDefault(ref txtShipperPostalCode, from.PostalCode);
                    Common.ApplyDefault(ref txtShipperCountry, from.CountryCode);
                    Common.ApplyDefault(ref txtShipperMobileNumber, from.MobileNumber);
                    Common.ApplyDefault(ref txtShipperEMailAddress, from.EMailAddress);
                }

                if (null != Common.Defaults.To)
                {
                    var to = Common.Defaults.To;
                    Common.ApplyDefault(ref txtConsigneeCompany, to.CompanyName);
                    Common.ApplyDefault(ref txtConsigneeName, to.PersonName);
                    Common.ApplyDefault(ref txtConsigneeAddress1, to.Address1);
                    Common.ApplyDefault(ref txtConsigneeAddress2, to.Address2);
                    Common.ApplyDefault(ref txtConsigneeAddress3, to.Address3);
                    Common.ApplyDefault(ref txtConsigneeCity, to.City);
                    Common.ApplyDefault(ref txtConsigneeState, to.USState);
                    Common.ApplyDefault(ref txtConsigneePostalCode, to.PostalCode);
                    Common.ApplyDefault(ref txtConsigneeCountry, to.CountryCode);
                    Common.ApplyDefault(ref txtConsigneeMobileNumber, to.MobileNumber);
                    Common.ApplyDefault(ref txtConsigneeEMailAddress, to.EMailAddress);
                }

                if (null != Common.Defaults.Pieces
                    && Common.Defaults.Pieces.Any())
                {
                    var piece = Common.Defaults.Pieces.First();

                    Common.ApplyDefault(ref cmbShipmentDimsUOM, piece.DimUnit, "CM");
                    Common.ApplyDefault(ref cmbShipmentWeightUOM, piece.WeightUnit, "KG");

                    Common.ApplyDefault(ref txtShipmentWeight, piece.Weight);
                    Common.ApplyDefault(ref txtShipmentHeight, piece.Height);
                    Common.ApplyDefault(ref txtShipmentWidth, piece.Width);
                    Common.ApplyDefault(ref txtShipmentDepth, piece.Depth);

                    if (null != piece.Height
                        && null != piece.Width
                        && null != piece.Depth)
                    {
                        decimal preDivisor = (decimal) (piece.Height * piece.Width * piece.Depth);

                        txtShipmentDimWeight.Text = $"{preDivisor / 5000:#,##0.00}";
                    }
                    Common.ApplyDefault(ref txtShipmentContents, piece.PieceContents, string.Empty, true);
                }
            }
            else
            {
                cmbShipmentDimsUOM.SelectedItem = "CM";
                cmbShipmentWeightUOM.SelectedItem = "KG";
            }

            cmbProductCode.SelectedItem = "P";
        }

        private void Create_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BtnRequestPickup_Click(object sender, EventArgs e)
        {
            ClearInputErrors();

            SetStatusText("Validating inputs...", true, true, 0);

            // Set our time counters
            DateTime processStart = DateTime.Now;

            // Validate all our inputs
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fix the issues on the inputs marked in red.");
                SetStatusText("Input validation failed!", false);
                return;
            }

            // All validation done, send the data to GloWS.
#pragma warning disable IDE0017 // Simplify object initialization
            try
            {
                this.Enabled = false;

                // Clear result fields
                txtResultBookingReferenceNumber.Clear();
                Application.DoEvents();

                // Determine if this is a dox or non-dox shipment
                bool isDox = !(new[] { "3", "4", "8", "E", "F", "H", "J", "M", "P", "Q", "V", "Y" }).Contains(cmbProductCode.SelectedValue.ToString());
                bool isDomestic = "N" == cmbProductCode.Text;

                SetStatusText("Preparing request...", true, true, 10);

                MyDHLAPI api = new MyDHLAPI_REST_Library.MyDHLAPI(Common.CurrentCredentials["Username"]
                                                                  , Common.CurrentCredentials["Password"]
                                                                  , Common.CurrentRestBaseUrl);

                CreatePickupRequest req = new CreatePickupRequest();

                /*** Request Header ***/
                //req.PickUpRequest.Request = new Request()
                //{
                //    ServiceHeader = new ServiceHeader()
                //    {
                //        ShippingSystemPlatform = "MyDHL API Test App"
                //        , ShippingSystemPlatformVersion = Application.ProductVersion
                //        , Plugin = "MyDHL API C# Library"
                //        , PluginVersion = api.GetVersion()
                //    }
                //};

#pragma warning restore IDE0017 // Simplify object initialization
                req.PickUpRequest = new PickUpRequest
                {
                    PickUpShipment = new PickUpShipment
                    {
                        ShipmentDetails = new ShipmentDetails()
                        {
                            ShipmentDetail = new ShipmentDetail()
                            {
                                ServiceType = cmbProductCode.SelectedValue.ToString(),
                                LocalServiceType = cmbProductCode.SelectedValue.ToString()
                            }
                        }
                    }
                };

                // SU = Standard (american) Units (LB, IN); SI = Standard International (KG, CM)
                if ("KG" == cmbShipmentWeightUOM.SelectedValue.ToString())
                {
                    req.PickUpRequest.PickUpShipment.ShipmentDetails.ShipmentDetail.UnitOfMeasurement = Enums.UnitOfMeasurement.SI;
                }
                else
                {
                    req.PickUpRequest.PickUpShipment.ShipmentDetails.ShipmentDetail.UnitOfMeasurement = Enums.UnitOfMeasurement.SU;
                }

                // If the billing element is defined (it should be used anyway) then there is no need for the
                // generic shipmentInfo.Account element to be populated.
                //shipmentInfo.Account = txtShipperAccountNumber.Text;
                req.PickUpRequest.PickUpShipment.Billing = new Billing(txtShipperAccountNumber.Text
                                                                       , Enums.PaymentTypes.Shipper);
                DateTime timestamp;

                if (DateTime.Now.TimeOfDay > new TimeSpan(18, 00, 00))
                {
                    timestamp = DateTime.Now.AddDays(1);
                    timestamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 10, 0, 0);
                }
                else
                {
                    timestamp = DateTime.Now.AddMinutes(10);
                }

                req.PickUpRequest.PickUpShipment.PickupTimestamp = timestamp;
                req.PickUpRequest.PickUpShipment.PickupLocationCloseTime = timestamp.AddHours(4).TimeOfDay;

                req.PickUpRequest.PickUpShipment.Addresses = new AddressInformation();

                req.PickUpRequest.PickUpShipment.Remarks = txtRemarks.Text;

                /*** SHIPPER ***/
                AddressData shipper = new AddressData();

                if (!IsBlank(txtShipperCompany))
                {
                    shipper.Contact.CompanyName = txtShipperCompany.Text;
                }
                else
                {
                    shipper.Contact.CompanyName = txtShipperName.Text;
                }
                shipper.Contact.PersonName = txtShipperName.Text;
                shipper.Contact.EMailAddress = txtShipperEMailAddress.Text;
                shipper.Contact.PhoneNumber = txtShipperMobileNumber.Text;

                shipper.Address.AddressLine1 = txtShipperAddress1.Text;
                shipper.Address.AddressLine2 = txtShipperAddress2.Text;
                shipper.Address.AddressLine3 = txtShipperAddress3.Text;
                shipper.Address.CityName = txtShipperCity.Text;
                shipper.Address.USStateCode = txtShipperState.Text;
                shipper.Address.CountryCode = txtShipperCountry.Text;
                shipper.Address.PostalOrZipCode = txtShipperPostalCode.Text;

                req.PickUpRequest.PickUpShipment.Addresses.Shipper = shipper;

                /*** CONSIGNEE ***/
                AddressData consignee = new AddressData();

                if (!IsBlank(txtConsigneeCompany))
                {
                    consignee.Contact.CompanyName = txtConsigneeCompany.Text;
                }
                else
                {
                    consignee.Contact.CompanyName = txtConsigneeName.Text;
                }
                consignee.Contact.PersonName = txtConsigneeName.Text;
                consignee.Contact.EMailAddress = txtConsigneeEMailAddress.Text;
                consignee.Contact.PhoneNumber = txtConsigneeMobileNumber.Text;

                consignee.Address.AddressLine1 = txtConsigneeAddress1.Text;
                consignee.Address.AddressLine2 = txtConsigneeAddress2.Text;
                consignee.Address.AddressLine3 = txtConsigneeAddress3.Text;
                consignee.Address.CityName = txtConsigneeCity.Text;
                consignee.Address.USStateCode = txtConsigneeState.Text;
                consignee.Address.CountryCode = txtConsigneeCountry.Text;
                consignee.Address.PostalOrZipCode = txtConsigneePostalCode.Text;

                req.PickUpRequest.PickUpShipment.Addresses.Recipient = consignee;

                /*** PICKUP ***/
                if (!cbxIgnorePickupSection.Checked)
                {
                    AddressData pickupAddress = new AddressData();

                    if (!IsBlank(txtPickupCompany))
                    {
                        pickupAddress.Contact.CompanyName = txtPickupCompany.Text;
                    }
                    else
                    {
                        pickupAddress.Contact.CompanyName = txtPickupName.Text;
                    }
                    pickupAddress.Contact.PersonName = txtPickupName.Text;
                    pickupAddress.Contact.EMailAddress = txtPickupEMailAddress.Text;
                    pickupAddress.Contact.PhoneNumber = txtPickupMobileNumber.Text;

                    pickupAddress.Address.AddressLine1 = txtPickupAddress1.Text;
                    pickupAddress.Address.AddressLine2 = txtPickupAddress2.Text;
                    pickupAddress.Address.AddressLine3 = txtPickupAddress3.Text;
                    pickupAddress.Address.CityName = txtPickupCity.Text;
                    pickupAddress.Address.USStateCode = txtPickupState.Text;
                    pickupAddress.Address.CountryCode = txtPickupCountry.Text;
                    pickupAddress.Address.PostalOrZipCode = txtPickupPostalCode.Text;

                    req.PickUpRequest.PickUpShipment.Addresses.Pickup = pickupAddress;
                }
                /*** REQUESTOR ***/
                if (!cbxIgnoreRequestor.Checked)
                {

                    AddressData requestorAddress = new AddressData();

                    if (!IsBlank(txtRequestorCompany))
                    {
                        requestorAddress.Contact.CompanyName = txtRequestorCompany.Text;
                    }
                    else
                    {
                        requestorAddress.Contact.CompanyName = txtRequestorName.Text;
                    }
                    requestorAddress.Contact.PersonName = txtRequestorName.Text;
                    requestorAddress.Contact.EMailAddress = txtRequestorEMailAddress.Text;
                    requestorAddress.Contact.PhoneNumber = txtRequestorMobileNumber.Text;

                    requestorAddress.Address.AddressLine1 = txtRequestorAddress1.Text;
                    requestorAddress.Address.AddressLine2 = txtRequestorAddress2.Text;
                    requestorAddress.Address.AddressLine3 = txtRequestorAddress3.Text;
                    requestorAddress.Address.CityName = txtRequestorCity.Text;
                    requestorAddress.Address.USStateCode = txtRequestorState.Text;
                    requestorAddress.Address.CountryCode = txtRequestorCountry.Text;
                    requestorAddress.Address.PostalOrZipCode = txtRequestorPostalCode.Text;

                    req.PickUpRequest.PickUpShipment.Addresses.BookingRequestor = requestorAddress;
                }

                /*** PIECES ***/
                Package singlePackage = new Package
                {
                    PackageNumber = 1,
                    Weight = decimal.Parse($"{txtShipmentWeight.Text}"),
                    CustomerReferences = txtShipmentReference.Text,
                };

                decimal height = GetDimension(ref txtShipmentHeight);
                decimal width = GetDimension(ref txtShipmentWidth);
                decimal depth = GetDimension(ref txtShipmentDepth);

                if (height > 0
                    && width > 0
                    && depth > 0)
                {
                    // Keep the divisor at 5000.0, this forces .NET to treate the result as a float and not an integer.
                    singlePackage.Dimensions = new Dimensions(height, width, depth);
                }

                req.PickUpRequest.PickUpShipment.ShipmentDetails.ShipmentDetail.Packages = new Packages
                {
                    PackageList = new List<Package>
                    {
                        singlePackage
                    }
                };

                /*** GENERATE PICKUP ***/
                CreatePickupResponse resp;

                SetStatusText("Sending shipment request...", true, true, 40);

                DateTime pickupRequestStart = DateTime.Now;
                DateTime pickupRequestEnd = DateTime.Now;
                try
                {
                    pickupRequestStart = DateTime.Now;
                    resp = api.RequestNewPickupAsync(req).Result;
                }
                catch (MyDHLAPIValidationException gvx)
                {
                    MessageBox.Show(gvx.Message, "GVX");
                    txtResultBookingReferenceNumber.Text = "VALIDATION ERROR!";
                    if (gvx.Data.Contains("ValidationResults"))
                    {
                        txtMessages.Text = MyDHLAPIValidationException.PrintResults((List<ValidationResult>)gvx.Data["ValidationResults"]);
                    }
                    SetStatusText($"Shipment contains validation errors! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                    return;
                }
                catch (Exception ex)
                {
                    if (null != ex.InnerException
                        && ex.InnerException is MyDHLAPIValidationException)
                    {
                        MyDHLAPIValidationException gvx = (MyDHLAPIValidationException)ex.InnerException;
                        txtResultBookingReferenceNumber.Text = "VALIDATION ERROR!";
                        if (gvx.Data.Contains("ValidationResults"))
                        {
                            txtMessages.Text = MyDHLAPIValidationException.PrintResults((List<ValidationResult>)gvx.Data["ValidationResults"]);
                        }
                        SetStatusText($"Shipment contains validation errors! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                        return;
                    }

                    MessageBox.Show(ex.Message, "EX");
                    txtResultBookingReferenceNumber.Text = "ERROR!";
                    SetStatusText($"Shipment error! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                    return;
                }
                finally
                {
                    pickupRequestEnd = DateTime.Now;
                }

                MyDHLAPI_Request = api.LastNewPickupJSONRequest;
                MyDHLAPI_Response = api.LastNewPickupJSONResponse;

                if (null == resp || !Notification.HasSuccessCode(resp.Notifications))
                {
                    MessageBox.Show("There was an error in requesting the pickup.");
                    SetStatusText($"Pickup generation failed! Took {(DateTime.Now - processStart):c}", false);
                    return;
                }

                SetStatusText($"Pickup Requested, displaying results...", true, true, 50);

                // Display our results

                txtResultBookingReferenceNumber.Text = (string.IsNullOrEmpty(resp.PickupRequestNumber) ? string.Empty : resp.PickupRequestNumber);
                txtMessages.Text = Notification.GetAllNotifications(resp.Notifications, Environment.NewLine);

                DateTime processEnd = DateTime.Now;

                /*** Save for cancelation ***/
                AddressData pickupSection = (req.PickUpRequest.PickUpShipment.Addresses.Pickup ?? req.PickUpRequest.PickUpShipment.Addresses.Shipper);
                AddressData bookingRequestorSection = (req.PickUpRequest.PickUpShipment.Addresses.BookingRequestor ?? pickupSection);
                Common.SuccessfulPickupRequests.Add(new Objects.SuccessfulPickupRequest()
                {
                    PickupDate = req.PickUpRequest.PickUpShipment.PickupTimestamp
                    , PickupCountry = pickupSection.Address.CountryCode
                    , RequestorName = bookingRequestorSection.Contact.PersonName
                    , PickupRequestNumber = resp.PickupRequestNumber
                });

                /*** Set status bar time sections ***/
                SetStatusTimeText(ref tsslPickupTimeLabel, ref tsslPickupTime, pickupRequestStart, pickupRequestEnd);
                SetStatusTimeText(ref tsslTotalTimeLabel, ref tsslTotalTime, processStart, processEnd);
                SetStatusText("Process complete.", false);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void SetStatusText(string newStatus, bool showProgress = false, bool setProgress = false, int newProgress = 0)
        {
            tsslStatusLabel.Text = newStatus;
            tspbProgressBar.Visible = showProgress;
            if (setProgress)
            {
                tspbProgressBar.Value = newProgress;
            }
        }

        private void SetStatusTimeText(ref ToolStripStatusLabel label, ref ToolStripStatusLabel time, DateTime start, DateTime end)
        {
            time.Text = TimeDiffString(start, end);
            label.Visible = true;
            time.Visible = true;
        }

        private string TimeDiffString(DateTime start, DateTime? end)
        {
            if (null == end)
            {
                end = DateTime.Now;
            }

            if (start == end)
            {
                return "-- none --";
            }

            return $"{end - start:hh\\:mm\\:ss\\.fff}";
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
            decimal height = GetDimension(ref txtShipmentHeight);
            decimal width = GetDimension(ref txtShipmentWidth);
            decimal depth = GetDimension(ref txtShipmentDepth);

            if (height > 0
                && width > 0
                && depth > 0)
            {
                // Keep the divisor at 5000.0, this forces .NET to treate the result as a float and not an integer.
                txtShipmentDimWeight.Text = $"{(height * width * depth) / 5000.0M}";
            }
            else
            {
                txtShipmentDimWeight.Text = string.Empty;
            }
        }

        private decimal GetDimension(ref TextBox tbx)
        {
            ClearError(ref tbx);

            if (IsBlank(tbx))
            {
                return -1;
            }
            if (!Regex.IsMatch(tbx.Text, "^\\d+(\\.\\d{1,2})?$"))
            {
                IndicateError(ref tbx, "Please enter a valid whole number.");
                return 0;
            }
            try
            {
                decimal dim = decimal.Parse(tbx.Text);
                if (0 >= dim)
                {
                    IndicateError(ref tbx, "Please enter a non-zero positive number.");
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
            JSONViewer frm = new JSONViewer(MyDHLAPI_Request);
            frm.ShowDialog();
        }

        private void BtnViewResponse_Click(object sender, EventArgs e)
        {
            JSONViewer frm = new JSONViewer(MyDHLAPI_Response);
            frm.ShowDialog();
        }

        private void BtnCopyFrom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string[] toFrom = ((string)btn.Tag).Split('|');

            string to = toFrom[0];
            string from = toFrom[1];

            foreach (KeyValuePair<string, TextBox> tbx in _addressInputs[from])
            {
                CopyTexboxValue(tbx.Value, _addressInputs[to][tbx.Key]);
            }

            if (to.Equals("Requestor")
                || to.Equals("Pickup"))
            {
                if (from.Equals("Shipper"))
                {
                    cbxIgnoreRequestor.Checked = true;
                }
                else
                {
                    cbxIgnoreRequestor.Checked = false;
                }
            }
        }

        private void CopyTexboxValue(TextBox from, TextBox to)
        {
            to.Text = from.Text;
        }
    }
}
