using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyDHLAPI_REST_Library;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Common.Response;
using MyDHLAPI_REST_Library.Objects.RateQuery;
using MyDHLAPI_REST_Library.Objects.RateQuery.Response;

namespace MyDHLAPI_Test_App.REST {
    public partial class RateQuote : Form
    {

        private string _lastJsonRequest;
        private string _lastJsonResponse;

        public RateQuote() {
            InitializeComponent();
        }

        private void RateQuote_Load(object sender, EventArgs e)
        {
            cmbRequestCourier.SelectedIndex = 0;
            cmbDutiable.SelectedIndex = 0;
            cmbUOM.SelectedIndex = 0;

            cmbTermsOfTrade.DataSource = Enum.GetValues(typeof(Enums.TermsOfTrade));
            cmbTermsOfTrade.SelectedItem = Enums.TermsOfTrade.DDU;

            if (null != Common.Defaults)
            {
                Common.ApplyDefault(ref txtAccountShipper, Common.Defaults.ShipperAccountNumber);
                Common.ApplyDefault(ref txtAccountBilling, Common.Defaults.BillingAccountNumber);
                Common.ApplyDefault(ref ntxtDeclaredValue, Common.Defaults.DeclaredValue, 0.5M);
                Common.ApplyDefault(ref txtDeclaredCurrency, Common.Defaults.DeclaredCurrency);

                if (null != Common.Defaults.From)
                {
                    var from = Common.Defaults.From;
                    Common.ApplyDefault(ref txtShipperCity, from.City);
                    Common.ApplyDefault(ref txtShipperUSState, from.USState);
                    Common.ApplyDefault(ref txtShipperPostalCode, from.PostalCode);
                    Common.ApplyDefault(ref txtShipperCountry, from.CountryCode);
                }

                if (null != Common.Defaults.To)
                {
                    var to = Common.Defaults.To;
                    Common.ApplyDefault(ref txtConsigneeCity, to.City);
                    Common.ApplyDefault(ref txtConsigneeUSState, to.USState);
                    Common.ApplyDefault(ref txtConsigneePostalCode, to.PostalCode);
                    Common.ApplyDefault(ref txtConsigneeCountry, to.CountryCode);
                }

                if (null != Common.Defaults.Pieces
                    && Common.Defaults.Pieces.Any())
                {
                    var piece = Common.Defaults.Pieces.First();

                    Common.ApplyDefault(ref ntxtWeight, piece.Weight);
                    Common.ApplyDefault(ref ntxtHeight, piece.Height);
                    Common.ApplyDefault(ref ntxtWidth, piece.Width);
                    Common.ApplyDefault(ref ntxtLength, piece.Depth);
                }
            }
        }

        private void BtnViewRequest_Click(object sender, EventArgs e) {
            Form frm = new JSONViewer(_lastJsonRequest);
            frm.Show();
        }

        private void BtnViewResponse_Click(object sender, EventArgs e) {
            Form frm = new JSONViewer(_lastJsonResponse);
            frm.Show();
        }

        private void CmbDutiable_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox me = (ComboBox) sender;
            if (me.SelectedIndex == 1) {
                ntxtDeclaredValue.Enabled = true;
                txtDeclaredCurrency.Enabled = true;
                cmbTermsOfTrade.Enabled = true;
            } else {
                ntxtDeclaredValue.Enabled = false;
                txtDeclaredCurrency.Enabled = false;
                cmbTermsOfTrade.Enabled = false;
            }
        }

        private void CmbUOM_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox me = (ComboBox) sender;
            if (me.SelectedIndex == 1) {// SU selected
                lblUOMWeight.Text = "LB";
                lblUOMLength.Text = "in";
                lblUOMWidth.Text = "in";
                lblUOMHeight.Text = "in";
            } else {// SI selected
                lblUOMWeight.Text = "KG";
                lblUOMLength.Text = "cm";
                lblUOMWidth.Text = "cm";
                lblUOMHeight.Text = "cm";
            }
        }

        private void BtnGo_Click(object sender, EventArgs e) {
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                this.UseWaitCursor = true;

                MyDHLAPI glows = new MyDHLAPI(Common.CurrentCredentials["Username"]
                                        , Common.CurrentCredentials["Password"]
                                        , Common.CurrentRestBaseUrl);

                RateQueryRequest rqr = new RateQueryRequest();
                RateRequest rr = new RateRequest();
                RequestedShipment rs = new RequestedShipment
                {
                    DropOffType = (cmbRequestCourier.SelectedIndex == 0 ? Enums.DropOffType.RequestCourier : Enums.DropOffType.RegularPickup)
                    , DeclaredValue = ntxtDeclaredValue.Value
                    , DeclaredValueCurrencyCode = txtDeclaredCurrency.Text.Trim()
                    , NextBusinessDay = Enums.YesNo.Yes
                    , ShipTimestamp = DateTime.Now
                    , UnitOfMeasurement = (cmbUOM.SelectedIndex == 0 ? Enums.UnitOfMeasurement.SI : Enums.UnitOfMeasurement.SU)
                    , PaymentInfo = (Enums.TermsOfTrade) cmbTermsOfTrade.SelectedItem
                    , RequestValueAddedServices = (cbxShowAllServices.Checked ? Enums.YesNo.Yes : Enums.YesNo.No)
                    , Content = (cmbDutiable.SelectedIndex == 0 ? Enums.ShipmentType.Documents : Enums.ShipmentType.NonDocuments)
                };
                MyDHLAPI_REST_Library.Objects.RateQuery.Ship s = new MyDHLAPI_REST_Library.Objects.RateQuery.Ship();
                Address sa = new Address
                {
                    City = txtShipperCity.Text.Trim()
                    , PostalCode = txtShipperPostalCode.Text.Trim()
                    , USSateCode = txtShipperUSState.Text.Trim()
                    , CountryCode = txtShipperCountry.Text.Trim()
                };
                s.Shipper = sa;
                Address ra = new Address
                {
                    City = txtConsigneeCity.Text.Trim()
                    , PostalCode = txtConsigneePostalCode.Text.Trim()
                    , USSateCode = txtConsigneeUSState.Text.Trim()
                    , CountryCode = txtConsigneeCountry.Text.Trim()
                };
                s.Recipient = ra;
                rs.Ship = s;
                // 961187381
                Billing b = new Billing
                {
                    ShipperAccountNumber = txtAccountShipper.Text.Trim()
                    , BillingAccountNumber = txtAccountBilling.Text.Trim()
                    , ShippingPaymentType = (rbtnPayShipper.Checked ? Enums.PaymentTypes.Shipper : Enums.PaymentTypes.Receiver)
                };
                rs.Billing = b;
                Packages p = new Packages();
                List<RequestedPackages> rps = new List<RequestedPackages>
                {
                    new RequestedPackages
                    {
                        PieceNumber = 1
                        , Weight = new Weight {Value = ntxtWeight.Value}
                        , Dimensions = new Dimensions
                        {
                            Height = ntxtHeight.Value
                            , Width = ntxtWidth.Value
                            , Length = ntxtLength.Value
                        }
                    }
                };
                p.RequestedPackages = rps;
                rs.Packages = p;

                if ((Enums.TermsOfTrade) cmbTermsOfTrade.SelectedItem
                    == Enums.TermsOfTrade.DDP)
                {
                    SpecialServices sss = new SpecialServices
                    {
                        Service = new List<SpecialService>()
                    };
                    sss.Service.Add(new SpecialService("DD"));
                    rs.SpecialServices = sss;
                }

                rs.GetDetailedRateBreakdown = Enums.YesNo.Yes;

                rr.RequestedShipment = rs;
                rqr.RateRequest = rr;

                RateQueryResponse result = glows.RateQuery(rqr);

                _lastJsonRequest = glows.LastJSONRequest;
                _lastJsonResponse = glows.LastJSONResponse;

                tvResult.Nodes.Clear();

                if (null == result.Services)
                {
                    if (null != result.RateResponse.Provider)
                    {
                        if (1 == result.RateResponse.Provider.Count)
                        {
                            Provider provider = result.RateResponse.Provider.First();
                            if (provider.Notification.Any())
                            {
                                foreach (Notification notificaiton in provider.Notification)
                                {
                                    tvResult.Nodes.Add(notificaiton.Code, notificaiton.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        // We got no results back
                        tvResult.Nodes.Add("NONE", "--NONE--");
                    }
                }
                else
                {
                    foreach (Service service in result.Services)
                    {
                        TreeNode tn = new TreeNode($"{service.ProductCode}: {service.TotalNet.Currency} {service.TotalNet.Amount:#,##0.00}");
                        if (null != service.Charges)
                        {
                            foreach (Charge charge in service.Charges.Charge)
                            {
                                TreeNode ctn =
                                    new TreeNode(
                                        $"{charge.ChargeType}");
                                TreeNode cctn =
                                    new TreeNode($"{service.Charges.Currency} {charge.ChargeAmount:#,##0.00}");
                                ctn.Nodes.Add(cctn);
                                tn.Nodes.Add(ctn);
                            }
                        }

                        tn.ExpandAll();
                        tvResult.Nodes.Add(tn);
                    }
                }

                tvResult.Nodes[0].EnsureVisible();
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
                this.UseWaitCursor = false;
            }
        }
    }
}
