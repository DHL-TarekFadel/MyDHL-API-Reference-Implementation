using MyDHLAPI_REST_Library;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Exceptions;
using MyDHLAPI_REST_Library.Objects.Ship;
using MyDHLAPI_REST_Library.Objects.Ship.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_Test_App.REST
{
    public partial class Ship : Form
    {
        private readonly List<string> _productCodes = new List<string> { "", "0", "1", "2", "3", "4", "5", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string MyDHLAPI_Request = string.Empty;
        private string MyDHLAPI_Response = string.Empty;
        private string MyDHLAPI_RateQuery_Request = string.Empty;
        private string MyDHLAPI_RateQuery_Response = string.Empty;
        private string MyDHLAPI_ValidationError = string.Empty;

        private bool _logoAvailable;
        private byte[] _logoData;
        private string _logoMimeType;
        private bool _invoiceAvailable;
        private byte[] _invoiceData;

        private List<string> _generatedTempFiles = new List<string>();

        public Ship()
        {
            InitializeComponent();
        }

        private void Ship_Load(object sender, EventArgs e)
        {
            cmbProductCode.DataSource = _productCodes;
            cmbShipmentDimsUOM.DataSource = new[] { "", "CM", "IN" };
            cmbShipmentWeightUOM.DataSource = new[] { "", "KG", "LB" };

            if (null != Common.Defaults)
            {
                Common.ApplyDefault(ref txtShipperAccountNumber, Common.Defaults.ShipperAccountNumber);
                Common.ApplyDefault(ref txtDutyAccountNumber, Common.Defaults.DutyAccountNumber);
                Common.ApplyDefault(ref txtShipmentDeclaredValue, Common.Defaults.DeclaredValue, 0M);
                Common.ApplyDefault(ref txtShipmentDeclaredValueCurrency, Common.Defaults.DeclaredCurrency);
                Common.ApplyDefault(ref txtShipmentContents, Common.Defaults.ShipmentContents);
                Common.ApplyDefault(ref txtShipmentReference, Common.Defaults.ShipmentReference);
                Common.ApplyDefault(ref cbxRequestODDLink, Common.Defaults.RequestODDLink);

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

                if (null != Common.Defaults.Insurance)
                {
                    var insurance = Common.Defaults.Insurance;
                    Common.ApplyDefault(ref txtShipmentInsuredValue, insurance.InsuredAmount);
                    Common.ApplyDefault(ref txtShipmentInsuredCurrency, insurance.InsuredCurrency);
                    Common.ApplyDefault(ref cbxShipmentRequestInsurance, insurance.InsuranceEnabled);
                }

                if (null != Common.Defaults.CoD)
                {
                    var cod = Common.Defaults.CoD;
                    Common.ApplyDefault(ref txtShipmentCoDValue, cod.CoDAmount);
                    Common.ApplyDefault(ref txtShipmentCoDCurrency, cod.CoDCurrency);
                    Common.ApplyDefault(ref cbxRequestCoD, cod.CoDEnabled);
                }
            }
            else
            {
                cmbShipmentDimsUOM.SelectedItem = "CM";
                cmbShipmentWeightUOM.SelectedItem = "KG";
            }

            cmbProductCode.SelectedItem = "P";

            CmbProductCode_SelectedIndexChanged(cmbProductCode, new EventArgs());
            CbxShipmentRequestInsurance_CheckedChanged(cbxShipmentRequestInsurance, new EventArgs());
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

            SetStatusText("Validating inputs...", true, true, 0);

            // Set our time counters
            DateTime processStart = DateTime.Now;
            DateTime rateQueryRequestStart = DateTime.Now;
            DateTime rateQueryRequestEnd = DateTime.Now;
            DateTime shipRequestStart = DateTime.Now;
            DateTime shipRequestEnd = DateTime.Now;

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

                // Reset AWB link label
                llblAWB.Tag = null;
                llblAWB.LinkBehavior = LinkBehavior.NeverUnderline;
                llblAWB.ForeColor = Color.Black;
                llblAWB.Font = new Font(llblAWB.Font, FontStyle.Regular);

                // Clear result fields
                txtResultAWB.Clear();
                txtResultPieces.Clear();
                txtResultBookingReferenceNumber.Clear();
                Application.DoEvents();

                // Determine if this is a dox or non-dox shipment
                bool isDox = !(new[] { "3", "4", "8", "E", "F", "H", "J", "M", "P", "Q", "V", "Y" }).Contains(cmbProductCode.SelectedValue.ToString());
                bool isDomestic = "N" == cmbProductCode.Text;
                bool isDataStaging = cbxDataStaging.Checked;

                SetStatusText("Preparing request...", true, true, 10);

                MyDHLAPI api = new MyDHLAPI_REST_Library.MyDHLAPI(Common.CurrentCredentials["Username"]
                                                                  , Common.CurrentCredentials["Password"]
                                                                  , Common.CurrentRestBaseUrl);

                CreateShipmentRequest req = new CreateShipmentRequest();

                /*** Request Header ***/
                req.ShipmentRequest.Request = new Request()
                {
                    ServiceHeader = new ServiceHeader()
                    {
                        ShippingSystemPlatform = "MyDHL API Test App"
                        , ShippingSystemPlatformVersion = Application.ProductVersion
                        , Plugin = "MyDHL API C# Library"
                        , PluginVersion = api.GetVersion()
                    }
                };

#pragma warning restore IDE0017 // Simplify object initialization

                if (cbxShipmentRequestPickup.Checked)
                {
                    req.Data.ShipmentInfo.DropOffType = Enums.DropOffType.RequestCourier;
                }
                else
                {
                    req.Data.ShipmentInfo.DropOffType = Enums.DropOffType.RegularPickup;
                }

                string[] pltCountries = new string[] { "AE", "SA", "US"};
                bool isPLT = false;

                /*** PLT ***/
                if (!isDomestic
                    && !isDox
                    && !isDataStaging
                    && _invoiceAvailable
                    && (pltCountries.Contains(txtShipperCountry.Text)
                        || pltCountries.Contains(txtConsigneeCountry.Text))
                    )
                {
                    req.Data.ShipmentInfo.PaperlessTradeEnabled = true;
                    req.Data.ShipmentInfo.PaperlessTradeImage = _invoiceData;
                    isPLT = true;
                }

                req.Data.ShipmentInfo.GlobalProductCode = cmbProductCode.SelectedValue.ToString();
                
                // SU = Standard (american) Units (LB, IN); SI = Standard International (KG, CM)
                if ("KG" == cmbShipmentWeightUOM.SelectedValue.ToString())
                {
                    req.Data.ShipmentInfo.UnitOfMeasurement = Enums.UnitOfMeasurement.SI;
                }
                else
                {
                    req.Data.ShipmentInfo.UnitOfMeasurement = Enums.UnitOfMeasurement.SU;
                }

                // If the billing element is defined (it should be used anyway) then there is no need for the
                // generic shipmentInfo.Account element to be populated.
                //shipmentInfo.Account = txtShipperAccountNumber.Text;
                req.Data.ShipmentInfo.Billing = new BillingInfo(txtShipperAccountNumber.Text
                                                                 , txtShipperAccountNumber.Text
                                                                 , Enums.AccountRole.Shipper
                                                                 , txtDutyAccountNumber.Text);

                req.Data.ShipmentInfo.CurrencyCode = txtShipmentDeclaredValueCurrency.Text;

                req.Data.ShipmentInfo.LabelFormat = Enums.LabelFormat.PDF;
                req.Data.ShipmentInfo.LabelOptions = new LabelOptions
                {
                    HideAccountInWaybillDocument = Enums.YesNo.Yes
                };

                req.Data.ShipmentInfo.ShipmentReferences = new ShipmentReferences
                {
                    ShipmentReference = new List<ShipmentReference>
                    {
                        new ShipmentReference()
                        {
                            Reference = txtShipmentReference.Text,
                            ShipmentReferenceType = Enums.ShipmentReferenceType.Consignor
                        }
                    }
                };
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

                req.Data.Timestamp = timestamp;
                //.RequestedShipment.ShipTimestamp = $"{timestamp:s} GMT{timestamp:zzz}";

                if (!IsBlank(txtDutyAccountNumber) && cbxShipmentDDP.Checked)
                {
                    req.Data.TermsOfTrade = Enums.TermsOfTrade.DDP;
                }
                else
                {
                    req.Data.TermsOfTrade = Enums.TermsOfTrade.DDU;
                }


                if (!isDox && !isDomestic)
                {
                    req.Data.CustomsInformation.ShipmentType = Enums.ShipmentType.NonDocuments;
                    req.Data.CustomsInformation.Commodities = new Commodity
                    {
                        CustomsValue = decimal.Parse(txtShipmentDeclaredValue.Text),
                        ShipmentContents = txtShipmentContents.Text
                    };

                    if (cbxExportDeclaration.Checked)
                    {
                        ExportDeclaration exportDeclaration = new ExportDeclaration
                        {
                            InvoiceNumber = DateTime.Now.Ticks.ToString()
                            , InvoiceDate = DateTime.Now
                            , TermsOfPayment = "45 days credit"
                            , ExportLineItems = new ExportLineItems()
                        };
                        exportDeclaration.InvoiceSignatureDetails = new InvoiceSignatureDetails()
                        {
                            SignatureName = "James Deer"
                            , SignatureTitle = "Managing Director"
                        };
                        exportDeclaration.ExportLineItems.ExportLineItem = new List<ExportLineItem>
                        {
                            new ExportLineItem()
                            {
                                ItemNumber = 1 ,
                                ItemDescription = "TEST ITEM 1",
                                Quantity = 10,
                                QuantityUnitOfMeasurement = Enums.CustomsStatisticalUnitOfMeasurement.Pieces,
                                UnitPrice = (decimal.Parse(txtShipmentDeclaredValue.Text) / 2) / 10,
                                CommodityCode = "2345.65.15",
                                ExportReason = Enums.ExportReasonType.Permanent,
                                NetWeight = (decimal.Parse(txtShipmentWeight.Text) / 2) / 10,
                                GrossWeight = (decimal.Parse(txtShipmentWeight.Text) / 2) / 10
                            },
                            new ExportLineItem()
                            {
                                ItemNumber = 2,
                                ItemDescription = "TEST ITEM 2",
                                Quantity = 5,
                                QuantityUnitOfMeasurement = Enums.CustomsStatisticalUnitOfMeasurement.Pieces,
                                UnitPrice = (decimal.Parse(txtShipmentDeclaredValue.Text) / 2) / 5,
                                CommodityCode = "9876.54.32",
                                ExportReason = Enums.ExportReasonType.Permanent,
                                NetWeight = (decimal.Parse(txtShipmentWeight.Text) / 2) / 5,
                                GrossWeight = (decimal.Parse(txtShipmentWeight.Text) / 2) / 5
                            }
                        };
                        req.Data.CustomsInformation.ExportDeclaration = exportDeclaration;
                    }
                }
                else
                {
                    req.Data.CustomsInformation.ShipmentType = Enums.ShipmentType.Documents;
                    req.Data.CustomsInformation.Commodities = new Commodity()
                    {
                        ShipmentContents = txtShipmentContents.Text
                        , CustomsValue = (string.IsNullOrWhiteSpace(txtShipmentDeclaredValue.Text)
                                          ? 1.0M
                                          : decimal.Parse(txtShipmentDeclaredValue.Text))
                    };
                }


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

                req.Data.ShipmentAddresses.Shipper = shipper;

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

                req.Data.ShipmentAddresses.Consignee = consignee;

                /*** PICKUP ***/
                if (cbxShipmentRequestPickup.Checked)
                {
                    req.Data.ShipmentAddresses.Pickup = req.Data.ShipmentAddresses.Shipper;
                }

                /*** Notification(s) ***/
                if (cbxSendNotification.Checked)
                {
                    req.Data.ShipmentNotifications = new ShipmentNotifications()
                    {
                        ShipmentNotification = new List<ShipmentNotification>()
                        {
                            new ShipmentNotification()
                            {
                                EMailAddress = txtConsigneeEMailAddress.Text
                                , NotificationMethod = Enums.ShipmentNotificationMethods.EMail
                                , NotificationLanguage = Enums.ShipmentNotificationLanguages.English
                                , LanguageCountryCode = Enums.ShipmentNotificationLanguageCountryCode.US
                                , BespokeMessage = "Notification sent from the MyDHL API test app"
                            }
                            , new ShipmentNotification()
                            {
                                EMailAddress = txtShipperEMailAddress.Text
                                , NotificationMethod = Enums.ShipmentNotificationMethods.EMail
                                , NotificationLanguage = Enums.ShipmentNotificationLanguages.English
                                , LanguageCountryCode = Enums.ShipmentNotificationLanguageCountryCode.US
                                , BespokeMessage = "Notification sent from the MyDHL API test app"
                            }
                        }
                    };
                }

                /*** PIECES ***/

                Package singlePackage = new Package
                {
                    Number = 1,
                    Weight = decimal.Parse($"{txtShipmentWeight.Text}"),
                    CustomerReferences = txtShipmentReference.Text,
                    CustomerReferenceType = Enums.ShipmentReferenceType.Consignor                    
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

                singlePackage.PieceContents = (string.IsNullOrEmpty((string)txtShipmentContents.Tag) ? txtShipmentContents.Text : (string)txtShipmentContents.Tag);

                singlePackage.CustomerReferences = $"{DateTime.Now.Ticks}";

                req.Data.Packages.PackageList.Add(singlePackage);

                /*** SPECIAL SEVICES ***/

                SetStatusText("Getting services list...", true, true, 20);

                RateQueryRequest quote = null;
                RateQueryResponse rateQueryResponse = null;
                bool checkSpecialServices = false;
                // check if we need are requesting any special services
                if (isPLT || isDataStaging || cbxShipmentDDP.Checked || cbxRequestCoD.Checked || cbxShipmentRequestInsurance.Checked)
                {
                    checkSpecialServices = true;
                    // We will be requesting special services, do a query to ensure that the special service we need is available
                    quote = new RateQueryRequest
                    {
                        RateRequest = new MyDHLAPI_REST_Library.Objects.RateQuery.RateRequest
                        {
                            Request = req.ShipmentRequest.Request,
                            RequestedShipment = new MyDHLAPI_REST_Library.Objects.RateQuery.RequestedShipment
                            {
                                GetRateEstimate = Enums.YesNo.No,
                                GetDetailedRateBreakdown = Enums.YesNo.No,
                                RequestValueAddedServices = Enums.YesNo.Yes,
                                NextBusinessDay = Enums.YesNo.Yes,
                                ServiceType = req.Data.ShipmentInfo.GlobalProductCode,
                                ShipTimestamp = DateTime.Now.AddMinutes(5),
                                UnitOfMeasurement = Enums.UnitOfMeasurement.SI,
                                DeclaredValue = req.Data.CustomsInformation.Commodities.CustomsValue,
                                DeclaredValueCurrencyCode = req.Data.ShipmentInfo.CurrencyCode,
                                PaymentInfo = req.Data.TermsOfTrade,
                                Account = (req.Data.ShipmentInfo.AccountNumber ?? req.Data.ShipmentInfo.Billing.ShipperAccount),
                                Content = req.Data.CustomsInformation.ShipmentType,
                                Packages = new MyDHLAPI_REST_Library.Objects.RateQuery.Packages()
                                {
                                    RequestedPackages = new List<MyDHLAPI_REST_Library.Objects.RateQuery.RequestedPackages>()
                                },
                                Ship = new MyDHLAPI_REST_Library.Objects.RateQuery.Ship
                                {
                                    Shipper = req.Data.ShipmentAddresses.Shipper.Address,
                                    Recipient = req.Data.ShipmentAddresses.Consignee.Address
                                },

                            }
                        }
                    };
                    req.Data.Packages.PackageList.ForEach(p => quote.RateRequest.RequestedShipment.Packages.RequestedPackages.Add(p));

                    try
                    {
                        rateQueryRequestStart = DateTime.Now;
                        rateQueryResponse = api.RateQueryAsync(quote).Result;
                    }
                    catch
                    {
                        // Do nothing, we'll handle this later.
                    }
                    finally
                    {
                        rateQueryRequestEnd = DateTime.Now;
                        MyDHLAPI_RateQuery_Request = api.LastJSONRequest;
                        MyDHLAPI_RateQuery_Response = api.LastJSONResponse;
                    }
                }

                MyDHLAPI_REST_Library.Objects.RateQuery.Response.Charges availableChargeCodes = null;
                if (checkSpecialServices)
                {
                    if (null == rateQueryResponse.Services)
                    {
                        txtResultAWB.Text = "Rate Query Error!";
                        SetStatusText($"Rate query Error! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                        return;
                    }
                    else
                    {
                        availableChargeCodes = rateQueryResponse.Services.First().Charges;
                    }
                }

                SetStatusText("Received list of services.", true, true, 30);

                req.Data.ShipmentInfo.SpecialServices = new SpecialServices
                {
                    Service = new List<SpecialService>()
                };

                List<string> invalidServices = new List<string>();

                if (isPLT && !isDataStaging)
                {
                    if (availableChargeCodes.HasCharge("WY"))
                    {
                        req.Data.ShipmentInfo.SpecialServices.Service.Add(new SpecialService("WY"));
                    }
                    else
                    {
                        invalidServices.Add("PLT");
                    }
                }

                if (isDataStaging)
                {
                    if (availableChargeCodes.HasCharge("PT"))
                    {
                        req.Data.ShipmentInfo.SpecialServices.Service.Add(new SpecialService("PT"));
                    }
                    else
                    {
                        invalidServices.Add("Data Staging");
                    }
                }

                if (cbxShipmentDDP.Checked)
                {
                    if (availableChargeCodes.HasCharge("DD"))
                    {
                        req.Data.ShipmentInfo.SpecialServices.Service.Add(new SpecialService("DD"));
                    }
                    else
                    {
                        invalidServices.Add("Duties & Taxes Paid (DDP)");
                    }
                }

                if (cbxRequestCoD.Checked)
                {
                    if (availableChargeCodes.HasCharge("KB"))
                    {
                        req.Data.ShipmentInfo.SpecialServices.Service.Add(
                            new SpecialService("KB"
                                               , decimal.Parse(txtShipmentCoDValue.Text)
                                               , txtShipmentCoDCurrency.Text));
                    }
                    else
                    {
                        invalidServices.Add("Cash on Delivery");
                    }
                }

                if (cbxShipmentRequestInsurance.Checked)
                {
                    if (availableChargeCodes.HasCharge(cbxShipmentRequestInsurance.Tag.ToString()))
                    {
                        req.Data.ShipmentInfo.SpecialServices.Service.Add(
                            new SpecialService(cbxShipmentRequestInsurance.Tag.ToString()
                                               , decimal.Parse(txtShipmentInsuredValue.Text)
                                               , txtShipmentInsuredCurrency.Text));
                    }
                    else
                    {
                        invalidServices.Add($"Insurance ({cbxShipmentRequestInsurance.Tag})");
                    }
                }

                if (invalidServices.Any())
                {
                    string listSeparator = $"{Environment.NewLine}- ";
                    SetStatusText("Confirm removal of invalid services...", true, false);
                    if (DialogResult.No
                        == MessageBox.Show($"The services below are invalid between origin and destination:{listSeparator}{string.Join(listSeparator, invalidServices.ToArray())}{Environment.NewLine}{Environment.NewLine}Would you like to continue anyway?"
                                           , "Invalid Services Detected"
                                           , MessageBoxButtons.YesNo
                                           , MessageBoxIcon.Warning
                                           , MessageBoxDefaultButton.Button2))
                    {
                        txtResultAWB.Text = "Check Services!";
                        SetStatusText($"Check requested services! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                        return;
                    }
                }

                // DG Shipment
                if (cbxDGShipment.Checked)
                {
                    req.Data.ShipmentInfo.SpecialServices.Service.Add(
                        new SpecialService(cmbDGSpecialServiceCode.SelectedItem.ToString())
                    );
                    req.Data.DG = new DangerousGoods
                    {
                        DangerousGood = new List<DangerousGood>
                        {
                            new DangerousGood()
                            {
                                ContentId = txtDGClassification.Text
                            }
                        }
                    };
                }

                if (!req.Data.ShipmentInfo.SpecialServices.Service.Any())
                {
                    req.Data.ShipmentInfo.SpecialServices = null;
                }

                if (_logoAvailable)
                {
                    if (null == req.Data.ShipmentInfo.LabelOptions)
                    {
                        req.Data.ShipmentInfo.LabelOptions = new LabelOptions();
                    }

                    req.Data.ShipmentInfo.LabelOptions.CustomerLogo = new CustomerLogo(_logoData, _logoMimeType);
                }

                req.Data.ShipmentInfo.RequestAdditionalInformation = Enums.YesNo.Yes;
                req.Data.RequestODDUrl = (cbxRequestODDLink.Checked ? Enums.YesNo.Yes : Enums.YesNo.No);
                req.Data.GetRateEstimates = Enums.YesNo.Yes;

                /*** GENERATE SHIPMENT ***/
                CreateShipmentResponse resp;

                SetStatusText("Sending shipment request...", true, true, 40);

                try
                {
                    shipRequestStart = DateTime.Now;
                    resp = api.RequestShipmentAsync(req).Result;
                }
                catch (MyDHLAPIValidationException gvx)
                {
                    MessageBox.Show(gvx.Message, "GVX");
                    txtResultAWB.Text = "VALIDATION ERROR!";
                    if (gvx.Data.Contains("ValidationResults"))
                    {
                        txtResultPieces.Text = MyDHLAPIValidationException.PrintResults((List<ValidationResult>)gvx.Data["ValidationResults"]);
                    }
                    SetStatusText($"Shipment contains validation errors! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                    return;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException?.GetType() == typeof(MyDHLAPIValidationException))
                    {
                        MyDHLAPIValidationException gvx = (MyDHLAPIValidationException)ex.InnerException;
                        MessageBox.Show(gvx.Message, "GVX");
                        txtResultAWB.Text = "VALIDATION ERROR!";
                        if (gvx.Data.Contains("ValidationResults"))
                        {
                            txtResultPieces.Text = MyDHLAPIValidationException.PrintResults((List<ValidationResult>)gvx.Data["ValidationResults"]);
                        }
                        SetStatusText($"Shipment contains validation errors! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                        return;
                    }

                    MessageBox.Show(ex.Message, "EX");
                    txtResultAWB.Text = "ERROR!";
                    SetStatusText($"Shipment error! Took {(DateTime.Now - processStart):hh\\:mm\\:ss}", false);
                    return;
                }
                finally
                {
                    shipRequestEnd = DateTime.Now;
                }

                MyDHLAPI_Request = api.LastJSONRequest;
                MyDHLAPI_Response = api.LastJSONResponse;

                if (null == resp || null == resp.Data)
                {
                    MessageBox.Show("There was an error in generating the shipment.");
                    SetStatusText($"Shipment generation failed! Took {(DateTime.Now - processStart):HH:mm:ss}", false);
                    return;
                }

                SetStatusText($"Shipment generated, displaying results...", true, true, 50);

                // Display our results

                txtResultAWB.Text = (resp.Data.AWB ?? String.Empty);

                if (null != resp.Data.BookingReferenceNumber)
                {
                    txtResultBookingReferenceNumber.Text = resp.Data.BookingReferenceNumber;

                    /*** Save for cancelation ***/
                    Common.SuccessfulPickupRequests.Add(new Objects.SuccessfulPickupRequest()
                    {
                        PickupDate = req.Data.Timestamp
                        , PickupCountry = req.Data.ShipmentAddresses.Pickup.Address.CountryCode
                        , RequestorName = req.Data.ShipmentAddresses.Shipper.Contact.PersonName
                        , PickupRequestNumber = resp.Data.BookingReferenceNumber
                    });
                }

                if (null != resp.Data.Pieces
                    && resp.Data.Pieces.Any())
                {
                    string prefix = string.Empty;
                    string pieces = string.Empty;

                    foreach (Piece piece in resp.Data.Pieces)
                    {
                        pieces += $"{prefix}{piece.LPN}";
                        prefix = Environment.NewLine;
                    }

                    txtResultPieces.Text = pieces;
                }
                else
                {
                    txtResultPieces.Text = string.Empty;
                }

                if (null != resp.Data.Labels
                    && resp.Data.Labels.Any())
                {
                    int i = 0;
                    // Prepare our files for viewing
                    foreach (ShipmentImage label in resp.Data.Labels)
                    {
                        var tempFilename = Common.GetTempFilenameWithExtension(txtResultAWB.Text, label.ImageFormat);
                        File.WriteAllBytes(tempFilename, label.ImageData);
                        _generatedTempFiles.Add(tempFilename);

                        if (0 == i++)
                        {
                            llblAWB.Tag = tempFilename;
                            llblAWB.LinkBehavior = LinkBehavior.AlwaysUnderline;
                            llblAWB.ForeColor = Color.White;
                            llblAWB.Font = new Font(llblAWB.Font, FontStyle.Bold | FontStyle.Underline);
                        }
                    }
                }

                DateTime processEnd = DateTime.Now;

                SetStatusTimeText(ref tsslRateQueryTimeLabel, ref tsslRateQueryTime, rateQueryRequestStart, rateQueryRequestEnd);
                SetStatusTimeText(ref tsslShipTimeLabel, ref tsslShipTime, shipRequestStart, shipRequestEnd);
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

        private void LlblAWB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(llblAWB.Tag.ToString()))
            {
                System.Diagnostics.Process.Start(llblAWB.Tag.ToString());
            }
        }

        private void BtnUploadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.gif;*.jpg;*.jpeg;*.png",
                Multiselect = false,
                CheckFileExists = true
            };

            if (DialogResult.OK == dlg.ShowDialog())
            {
                _logoMimeType = MimeMapping.GetMimeMapping(dlg.FileName);
                _logoData = File.ReadAllBytes(dlg.FileName);
                _logoAvailable = true;
                lblLogoUploaded.Text = "Loaded!";
                lblLogoUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Bold);
            }
            else
            {
                if (_logoAvailable)
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show("No logo selected, would you like to remove the existing one?"
                                        , "Remove previous logo?"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button2))
                    {
                        _logoMimeType = string.Empty;
                        _logoData = null;
                        _logoAvailable = false;
                        lblLogoUploaded.Text = "Not Loaded";
                        lblLogoUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Regular);
                    }

                }
            }
        }

        private void BtnUploadInvoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|PDF Files|*.pdf",
                Multiselect = false,
                CheckFileExists = true
            };

            if (DialogResult.OK == dlg.ShowDialog())
            {
                _invoiceData = File.ReadAllBytes(dlg.FileName);
                _invoiceAvailable = true;
                lblInvoiceUploaded.Text = "Loaded!";
                lblInvoiceUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Bold);
            }
            else
            {
                if (_invoiceAvailable)
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show("No invoice selected, would you like to remove the existing one?"
                                        , "Remove previous invoice?"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button2))
                    {
                        _invoiceData = null;
                        _invoiceAvailable = false;
                        lblInvoiceUploaded.Text = "Not Loaded";
                        lblInvoiceUploaded.Font = new Font(lblLogoUploaded.Font, FontStyle.Regular);
                    }

                }
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
                    cbxShipmentRequestInsurance.Tag = "IB";
                    break;
                default:
                    cbxShipmentRequestInsurance.Tag = "II";
                    break;
            }
        }

        private void CbxShipmentRequestInsurance_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;

            txtShipmentInsuredValue.Enabled = cbx.Checked;
            txtShipmentInsuredCurrency.Enabled = cbx.Checked;
        }

        private void CbxRequestCoD_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            txtShipmentCoDValue.Enabled = cbx.Checked;
            txtShipmentCoDCurrency.Enabled = cbx.Checked;
        }

        private void CbxDataStaging_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            btnUploadInvoice.Enabled = !cbx.Checked;
            lblInvoiceUploaded.Enabled = !cbx.Checked;
        }

        private void CbxDGShipment_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;

            cmbDGSpecialServiceCode.Enabled = cbx.Checked;
            txtDGClassification.Enabled = cbx.Checked;
        }

        private void BtnViewError_Click(object sender, EventArgs e)
        {

        }
    }
}
