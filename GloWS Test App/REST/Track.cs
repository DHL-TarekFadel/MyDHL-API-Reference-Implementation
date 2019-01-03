using GloWS_REST_Library;
using GloWS_REST_Library.Objects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GloWS_REST_Library.Objects;
using GloWS_REST_Library.Objects.Exceptions;
using System.ComponentModel.DataAnnotations;
using GloWS_REST_Library.Objects.Tracking;
using GloWS_Test_App.Objects;

namespace GloWS_Test_App.REST
{
    public partial class Track : Form
    {
        private string _gloWsRequest;
        private string _gloWsResponse;

        public Track()
        {
            InitializeComponent();
        }

        private void Track_Load(object sender, EventArgs e)
        {
            if (null != Common.Defaults
                && !string.IsNullOrEmpty(Common.Defaults.TrackingAWBNumber))
            {
                txtTrackingNumber.Text = Common.Defaults.TrackingAWBNumber;
            }
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

                GloWS glows = new GloWS(Common.username, Common.password, (Common.IsProduction ? Common.restProductionBaseUrl : Common.restTestingBaseUrl));
                KnownTrackingResponse resp = null;
                
                try
                {
                    //if (10 == txtTrackingNumber.Text.Length)
                    //{
                    //    reqData.TrackingRequest.AWBNumber = new[] { txtTrackingNumber.Text.Trim() };
                    //}
                    //else
                    //{
                    //    reqData.TrackingRequest.LPNumber = new[] { txtTrackingNumber.Text.Trim() };
                    //}

                    resp = glows.KnownAWBTracking(new List<string>() { txtTrackingNumber.Text, "1234567891" }
                                                  , Enums.LevelOfDetails.AllCheckpoints
                                                  , Enums.PiecesEnabled.Both
                                                  , Enums.EstimatedDeliveryDateEnabled.Yes);

                    _gloWsRequest = glows.LastJSONRequest;
                    _gloWsResponse = glows.LastJSONResponse;
                }
                catch (GloWSValidationException ex)
                {
                    string msg = "Validation Failed:";
                    foreach (ValidationResult validationResult in ex.Data["ValidationResults"] as List<ValidationResult>)
                    {
                        msg += $"{Environment.NewLine}   {validationResult.ErrorMessage}";
                    }
                    MessageBox.Show(msg, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the most recent AWB Info (this is a common issue due to AWB reuse)
                AWBInfoItem shipment = resp.ActualResponse.AWBInfo.Aggregate((a1, a2) => a1.ArrayOfAWBInfoItem.ShipmentInfo.ShipmentDate > a2.ArrayOfAWBInfoItem.ShipmentInfo.ShipmentDate ? a1 : a2).ArrayOfAWBInfoItem;

                if (shipment.Status.ActionStatus.ToLower() != "success")
                {
                    MessageBox.Show("There was an error in tracking.");
                    return;
                }

                //if (string.IsNullOrWhiteSpace(shipment.AWBNumber)
                //    || "No Shipments Found" == shipment.Status.ActionStatus)
                //{
                //    MessageBox.Show("No shipment found with that AWB number");
                //    return;
                //}

                SetTextboxText(ref txtShipper, shipment.ShipmentInfo.ShipperName);
                SetTextboxText(ref txtConsignee, shipment.ShipmentInfo.ConsigneeName);
                SetTextboxText(ref txtShipmentDate, shipment.ShipmentInfo.ShipmentDate);
                SetTextboxText(ref txtNumberOfPieces, shipment.ShipmentInfo.Pieces);
                SetTextboxText(ref txtShipmentWeight, shipment.ShipmentInfo.Weight, true);
                //if (null != shipment.ShipmentInfo.ShipperReference)
                //{
                //    SetTextboxText(ref txtShipmentReference, shipment.ShipmentInfo.ShipperReference.ReferenceID);
                //}

                List<string> lastCheckpoints = new List<string>();
                foreach (PieceInfoItem piece in shipment.PieceInfo)
                {
                    if (null == piece.PieceEvents)
                    {
                        continue;
                    }
                    if (piece.PieceEvents.Any())
                    {
                        var lastCheckpoint = piece.PieceEvents.Aggregate((p1, p2) => p1.Date > p2.Date ? p1 : p2).ServiceEvent.EventCode;
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
                    foreach (EventItem shipmentEvent in shipment.ShipmentInfo.ShipmentEvents)
                    {
                        shipmentEvents.Add(new TrackingEventData(shipment.AWBNumber, shipmentEvent));
                    }
                    shipmentEvents.Sort((x, y) => x.Date.CompareTo(y.Date));
                    eventData.AddRange(shipmentEvents);
                }

                if (null != shipment.Pieces.PieceInfo)
                {
                    List<TrackingEventData> pieceEvents;
                    foreach (PieceInfoItem piece in shipment.PieceInfo)
                    {
                        if (null != piece.PieceEvents)
                        {
                            pieceEvents = new List<TrackingEventData>();
                            foreach (EventItem pieceEvent in piece.PieceEvents)
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

        private void SetTextboxText(ref TextBox tbx, string text, bool isWeight = false, string weightUnit = "KG")
        {
            if (!isWeight)
            {
                tbx.Text = text.Trim();
            }
            else
            {
                tbx.Text = $"{text.Trim()} {weightUnit}";

            }

        }

        private void SetTextboxText(ref TextBox tbx, int value)
        {
            tbx.Text = $"{value:#,##0}";
        }

        private void SetTextboxText(ref TextBox tbx, decimal value, bool isWeight = false, string weightUnit = "KG")
        {
            if (isWeight)
            {
                tbx.Text = $"{value:#,##0.00} {weightUnit}";
            }
            else
            {
                tbx.Text = $"{value:#,##0.00}";
            }
        }

        private void SetTextboxText(ref TextBox tbx, DateTime date)
        {
            tbx.Text = $"{date:yyyy-MM-dd HH:mm}";
        }

        private void BtnViewRequest_Click(object sender, EventArgs e)
        {
            JSONViewer frm = new JSONViewer(_gloWsRequest);
            frm.ShowDialog();
        }

        private void BtnViewResponse_Click(object sender, EventArgs e)
        {
            JSONViewer frm = new JSONViewer(_gloWsResponse);
            frm.ShowDialog();
        }

        private void TxtTrackingNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                BtnTrack_Click(btnTrack, new System.EventArgs());
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
