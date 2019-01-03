using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GloWS_Test_App.com.dhl.wsbexpress.track;
using System.ServiceModel.Channels;
using GloWS_Test_App.Objects;

namespace GloWS_Test_App.SOAP
{
    public partial class Track : Form
    {
        private string GloWS_Request;
        private string GloWS_Response;

        public Track()
        {
            InitializeComponent();
        }

        private void BtnTrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrackingNumber.Text))
            {
                MessageBox.Show("Please enter a tracking number.");
                return;
            }

            // We rely on AWB numbers being exactly 10 digits, trim the field.
            txtTrackingNumber.Text = txtTrackingNumber.Text.Trim();

#pragma warning disable IDE0017 // Simplify object initialization
            try
            {
                this.Enabled = false;

                pubTrackingRequest reqData = new pubTrackingRequest();

                reqData.TrackingRequest = new TrackingRequest();


                reqData.TrackingRequest.Request = new Request();
#pragma warning restore IDE0017 // Simplify object initialization
                reqData.TrackingRequest.Request.ServiceHeader = new ServiceHeader
                {
                    MessageReference = Guid.NewGuid().ToString("N"), // = DateTime.Now.Ticks.ToString();
                    MessageTime = DateTime.Now
                };

                if (10 == txtTrackingNumber.Text.Length)
                {
                    reqData.TrackingRequest.AWBNumber = new[] { txtTrackingNumber.Text.Trim() };
                }
                else
                {
                    reqData.TrackingRequest.LPNumber = new[] { txtTrackingNumber.Text.Trim() };
                }

                reqData.TrackingRequest.LevelOfDetails = LevelOfDetails.ALL_CHECK_POINTS;

                reqData.TrackingRequest.PiecesEnabled = "B";

                reqData.TrackingRequest.EstimatedDeliveryDateEnabled = true;
                reqData.TrackingRequest.EstimatedDeliveryDateEnabledSpecified = true;

                GloWS_Request = Common.XMLToString(reqData.GetType(), reqData);

                var glowsAuthData = Common.PrepareGlowsAuth("glDHLExpressTrack");

                gblDHLExpressTrackClient client = new gblDHLExpressTrackClient(new CustomBinding(glowsAuthData.Item2), glowsAuthData.Item1);
                client.ClientCredentials.UserName.UserName = glowsAuthData.Item3;
                client.ClientCredentials.UserName.Password = glowsAuthData.Item4;

                pubTrackingResponse resp;

                try
                {
                    resp = client.trackShipmentRequest(reqData);
                }
                catch (Exception ex)
                {
                    var text = ex.Message;
                    label1.Text = label1.Text + ".";
                    return;
                }

                //pubTrackingResponse resp = req.trackShipmentRequest(reqData);

                if (null != resp.TrackingResponse.Fault)
                {
                    MessageBox.Show("There was an error in tracking.");
                    return;
                }

                GloWS_Response = Common.XMLToString(resp.GetType(), resp);

                // Get the most recent AWB Info (this is a common issue due to AWB reuse)
                AWBInfo shipment = resp.TrackingResponse.AWBInfo.Aggregate((a1, a2) => a1.ShipmentInfo.ShipmentDate > a2.ShipmentInfo.ShipmentDate ? a1 : a2);

                if (string.IsNullOrWhiteSpace(shipment.AWBNumber)
                    || "No Shipments Found" == shipment.Status.ActionStatus)
                {
                    MessageBox.Show("No shipment found with that AWB number");
                    return;
                }

                SetTextboxText(ref txtShipper, shipment.ShipmentInfo.ShipperName);
                SetTextboxText(ref txtConsignee, shipment.ShipmentInfo.ConsigneeName);
                SetTextboxText(ref txtShipmentDate, shipment.ShipmentInfo.ShipmentDate);
                SetTextboxText(ref txtNumberOfPieces, shipment.ShipmentInfo.Pieces);
                SetTextboxText(ref txtShipmentWeight, shipment.ShipmentInfo.Weight, true, shipment.ShipmentInfo.WeightUnitSpecified, shipment.ShipmentInfo.WeightUnit);
                if (null != shipment.ShipmentInfo.ShipperReference)
                {
                    SetTextboxText(ref txtShipmentReference, shipment.ShipmentInfo.ShipperReference.ReferenceID);
                }
                List<string> lastCheckpoints = new List<string>();
                foreach (PieceInfo piece in shipment.Pieces.PieceInfo)
                {
                    if (piece.PieceEvent.Any())
                    {
                        var lastCheckpoint = piece.PieceEvent.Aggregate((p1, p2) => p1.Date > p2.Date ? p1 : p2).ServiceEvent.EventCode;
                        lastCheckpoints.Add(lastCheckpoint);
                    }
                    else
                    {
                        lastCheckpoints.Add("NONE");
                    }
                }

                SetTextboxText(ref txtShipmentLastCheckpoint, string.Join(" | ", lastCheckpoints));

                // Set up our tracking data list for display
                List<TrackingEventData> eventData = new List<TrackingEventData>();

                if (null != shipment.ShipmentInfo.ShipmentEvent)
                {
                    List<TrackingEventData> shipmentEvents = new List<TrackingEventData>();
                    foreach (ShipmentEvent shipmentEvent in shipment.ShipmentInfo.ShipmentEvent)
                    {
                        shipmentEvents.Add(new TrackingEventData(shipment.AWBNumber, shipmentEvent));
                    }
                    shipmentEvents.Sort((x, y) => x.Date.CompareTo(y.Date));
                    eventData.AddRange(shipmentEvents);
                }

                if (null != shipment.Pieces.PieceInfo)
                {
                    List<TrackingEventData> pieceEvents;
                    foreach (PieceInfo piece in shipment.Pieces.PieceInfo)
                    {
                        if (null != piece.PieceEvent)
                        {
                            pieceEvents = new List<TrackingEventData>();
                            foreach (PieceEvent pieceEvent in piece.PieceEvent)
                            {
                                pieceEvents.Add(new TrackingEventData(piece.PieceDetails.LicensePlate, pieceEvent));
                            }
                            pieceEvents.Sort((x, y) => x.Date.CompareTo(y.Date));
                            eventData.AddRange(pieceEvents);
                        }
                    }
                }

                dgvTrackingData.DataSource = eventData;

                dgvTrackingData.RowHeadersVisible = false;
                dgvTrackingData.AllowUserToOrderColumns = true;
                dgvTrackingData.AllowUserToResizeColumns = true;
                dgvTrackingData.AllowUserToResizeRows = false;

                // Set the column order(s)
                dgvTrackingData.Columns["Date"].DisplayIndex = 0;
                dgvTrackingData.Columns["TrackingNumber"].DisplayIndex = 1;
                dgvTrackingData.Columns["Code"].DisplayIndex = 2;
                dgvTrackingData.Columns["Description"].DisplayIndex = 3;
                dgvTrackingData.Columns["ServiceAreaCode"].DisplayIndex = 4;
                dgvTrackingData.Columns["ServiceAreaName"].DisplayIndex = 5;

                // Set the column headers(s)
                dgvTrackingData.Columns["TrackingNumber"].HeaderText = "AWB / LPN";
                dgvTrackingData.Columns["ServiceAreaCode"].HeaderText = "S.A.";
                dgvTrackingData.Columns["ServiceAreaName"].HeaderText = "S.A. Name";

                foreach (DataGridViewColumn col in dgvTrackingData.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                dgvTrackingData.Refresh();
                dgvTrackingData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void SetTextboxText(ref TextBox tbx, string text, bool isWeight = false, bool weightUnitSpecified = false, WeightUnit weightUnit = WeightUnit.K)
        {
            if (!isWeight)
            {
                tbx.Text = text.Trim();
            }
            else
            {
                if (weightUnitSpecified)
                {
                    tbx.Text = string.Format("{0} {1}", text, Enum.GetName(typeof(WeightUnit), weightUnit));
                }
                else
                {
                    tbx.Text = string.Format("{0} {1}", text, Enum.GetName(typeof(WeightUnit), WeightUnit.K));
                }
                
            }
            
        }

        private void SetTextboxText(ref TextBox tbx, DateTime date)
        {
            tbx.Text = string.Format("{0:yyyy-MM-dd HH:mm}", date);
        }

        private void BtnViewRequest_Click(object sender, EventArgs e)
        {
            XMLViewer frm = new XMLViewer(GloWS_Request);
            frm.ShowDialog();
        }

        private void BtnViewResponse_Click(object sender, EventArgs e)
        {
            XMLViewer frm = new XMLViewer(GloWS_Response);
            frm.ShowDialog();
        }
    }
}
