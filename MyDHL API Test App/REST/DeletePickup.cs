using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MyDHLAPI_REST_Library;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Common.Response;
using MyDHLAPI_REST_Library.Objects.Exceptions;
using MyDHLAPI_Test_App.Objects;

namespace MyDHLAPI_Test_App.REST
{
    // ReSharper disable once InconsistentNaming
    public partial class DeletePickup : Form
    {
        private string _lastJsonRequest;
        private string _lastJsonResponse;

        private List<string> tempFilenames = new List<string>();

        public DeletePickup()
        {
            InitializeComponent();
        }

        private void DeletePickup_Load(object sender, EventArgs e) {
            cmbReason.DataSource = Enum.GetValues(typeof(Enums.DeletePickupRequestReason));
            cmbReason.SelectedItem = Enums.DeletePickupRequestReason.OtherUnspecified;

            if (Common.SuccessfulPickupRequests.Any())
            {
                // Get the first successful pickup
                SuccessfulPickupRequest firstPickup = Common.SuccessfulPickupRequests.First();

                Common.ApplyDefault(ref txtPickupCountry, firstPickup.PickupCountry);
                Common.ApplyDefault(ref txtRequestorName, firstPickup.RequestorName);
                Common.ApplyDefault(ref txtPickupRequestNumber, firstPickup.PickupRequestNumber);
                Common.ApplyDefault(ref dtpPickupDate, firstPickup.PickupDate);
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

        private void BtnGo_Click(object sender, EventArgs e)
        {

            MyDHLAPI api = new MyDHLAPI(Common.CurrentCredentials["Username"]
                                        , Common.CurrentCredentials["Password"]
                                        , Common.CurrentRestBaseUrl);

            try
            {
                this.Enabled = false;
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrWhiteSpace(txtPickupCountry.Text)
                    || string.IsNullOrWhiteSpace(txtRequestorName.Text))
                {
                    MessageBox.Show(@"Missing data.");
                    return;
                }

                txtPickupCountry.Text = txtPickupCountry.Text.Trim();
                txtRequestorName.Text = txtRequestorName.Text.Trim();
                txtPickupRequestNumber.Text = txtPickupRequestNumber.Text.Trim();

                DeletePickupRequest req = new DeletePickupRequest
                {
                    DeleteRequest = new DeleteRequest
                    {
                        Request = new Request()
                        {
                            ServiceHeader = new ServiceHeader()
                            {
                                ShippingSystemPlatform = "MyDHL API Test App",
                                ShippingSystemPlatformVersion = Application.ProductVersion,
                                Plugin = "MyDHL API C# Library",
                                PluginVersion = api.GetVersion()
                            }
                        },
                        PickupDate = dtpPickupDate.Value,
                        PickupCountry = txtPickupCountry.Text,
                        RequestorName = txtRequestorName.Text,
                        PickupRequestNumber = txtPickupRequestNumber.Text,
                        Reason = (Enums.DeletePickupRequestReason)cmbReason.SelectedValue
                    }
                };

                DeletePickupResponse resp = api.RequestDeletePickupAsync(req).Result;

                if (null != resp)
                {
                    txtResult.Text = Notification.GetAllNotifications(resp.Notifications, Environment.NewLine);
                }
            }
            catch (MyDHLAPIValidationException gvx)
            {
                txtResult.Text = MyDHLAPIValidationException.PrintResults(gvx.ExtractValidationResults(), 0);
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                this.Enabled = true;
                this.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
                _lastJsonRequest = api.LastDeletePickupJSONRequest;
                _lastJsonResponse = api.LastDeletePickupJSONResponse;
            }
        }
    }
}
