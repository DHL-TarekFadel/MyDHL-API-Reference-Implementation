using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MyDHLAPI_REST_Library;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Exceptions;

namespace MyDHLAPI_Test_App.REST
{
    // ReSharper disable once InconsistentNaming
    public partial class ePOD : Form
    {
        private string _lastJsonRequest;
        private string _lastJsonResponse;

        private List<string> tempFilenames = new List<string>();

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

        private void EPOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool deleteFailed = false;

            foreach(string file in tempFilenames)
            {
                try
                {
                    File.Delete(file);
                }
                catch (IOException)
                {
                    deleteFailed = true;
                }
            }

            if (deleteFailed)
            {
                DialogResult result = MessageBox.Show("Could not delete all temp files, exit anyway?"
                                                      , "Cleanup failed"
                                                      , MessageBoxButtons.YesNo
                                                      , MessageBoxIcon.Warning
                                                      , MessageBoxDefaultButton.Button2);
                if (DialogResult.No == result)
                {
                    e.Cancel = true;
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

                MyDHLAPI api = new MyDHLAPI(Common.CurrentCredentials["Username"]
                                            , Common.CurrentCredentials["Password"]
                                            , Common.CurrentRestBaseUrl);

                EPodResponse ePod = api.GetEPod(txtAWBNumber.Text
                                                , txtAccountNumber.Text
                                                // ReSharper disable once PossibleInvalidCastException
                                                , (Enums.EPodType) cmbPODType.SelectedItem);

                _lastJsonRequest = api.LastEPoDJSONRequest;
                _lastJsonResponse = api.LastEPoDJSONResponse;
                
                if (null != ePod)
                {
                    string tempFilename = System.IO.Path.GetTempFileName();
                    switch (ePod.EPod.MimeType)
                    {
                        case "application/pdf":
                            tempFilename += ".pdf";
                            break;
                        case "image/jpeg":
                        case "image/jpg":
                            tempFilename += ".jpg";
                            break;
                        case "image/png":
                            tempFilename += ".png";
                            break;
                    }
                    System.IO.File.WriteAllBytes(tempFilename, ePod.EPod.Image);

                    System.Diagnostics.Process.Start(tempFilename);
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
            }
        }
    }
}
