using System;
using System.Windows.Forms;
using GloWS_REST_Library;
using GloWS_REST_Library.Objects;
using GloWS_REST_Library.Objects.Common;
using GloWS_REST_Library.Objects.Exceptions;

namespace GloWS_Test_App.REST
{
    // ReSharper disable once InconsistentNaming
    public partial class ePOD : Form
    {
        private string _lastJsonRequest;
        private string _lastJsonResponse;

        public ePOD()
        {
            InitializeComponent();
        }

        private void EPOD_Load(object sender, EventArgs e) {
            cmbPODType.DataSource = Enum.GetValues(typeof(Enums.EPodType));
            cmbPODType.SelectedItem = Enums.EPodType.Detailed;

            if (null != Common.Defaults
                && null != Common.Defaults.EPOD)
            {
                Common.ApplyDefault(ref txtAccountNumber, Common.Defaults.EPOD.AccountNumber);
                Common.ApplyDefault(ref txtAWBNumber, Common.Defaults.EPOD.AWBNumber);
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
            try
            {
                this.Enabled = false;
                this.UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrWhiteSpace(txtAccountNumber.Text)
                    || string.IsNullOrWhiteSpace(txtAWBNumber.Text))
                {
                    MessageBox.Show(@"Missing data.");
                    return;
                }

                txtAccountNumber.Text = txtAccountNumber.Text.Trim();
                txtAWBNumber.Text = txtAWBNumber.Text.Trim();

                GloWS glows = new GloWS(Common.CurrentCredentials["Username"]
                                        , Common.CurrentCredentials["Password"]
                                        , Common.CurrentRestBaseUrl);

                EPodResponse ePod = glows.GetEPod(txtAWBNumber.Text
                                                 , txtAccountNumber.Text
                                                 // ReSharper disable once PossibleInvalidCastException
                                                 , (Enums.EPodType) cmbPODType.SelectedItem);

                _lastJsonRequest = glows.LastJSONRequest;
                _lastJsonResponse = glows.LastJSONResponse;
                
                if (null != ePod)
                {
                    string tempFilename = System.IO.Path.GetTempFileName();
                    System.IO.File.WriteAllBytes(tempFilename, ePod.EPod.Image);

                    System.Diagnostics.Process.Start(tempFilename);
                }
            }
            catch (GloWSValidationException gvx)
            {
                txtResult.Text = GloWSValidationException.PrintResults(gvx.ExtractValidationResults(), 0);
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
            }
        }
    }
}
