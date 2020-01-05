namespace MyDHLAPI_Test_App.REST
{
    partial class Track
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShipper = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConsignee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShipmentDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberOfPieces = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShipmentWeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShipmentLastCheckpoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShipmentReference = new System.Windows.Forms.TextBox();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.btnViewResponse = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvTrackingData = new System.Windows.Forms.DataGridView();
            this.cmbTrackingType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnNextShipment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Delivery", 9F);
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "AWB/Piece ID:";
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtTrackingNumber.Location = new System.Drawing.Point(95, 20);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(167, 22);
            this.txtTrackingNumber.TabIndex = 1;
            this.txtTrackingNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTrackingNumber_KeyUp);
            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrack.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnTrack.Location = new System.Drawing.Point(496, 20);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(78, 25);
            this.btnTrack.TabIndex = 3;
            this.btnTrack.Text = "TRACK";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.BtnTrack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Delivery", 9F);
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shipper:";
            // 
            // txtShipper
            // 
            this.txtShipper.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtShipper.Location = new System.Drawing.Point(80, 50);
            this.txtShipper.Name = "txtShipper";
            this.txtShipper.ReadOnly = true;
            this.txtShipper.Size = new System.Drawing.Size(164, 22);
            this.txtShipper.TabIndex = 1;
            this.txtShipper.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Delivery", 9F);
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Consignee:";
            // 
            // txtConsignee
            // 
            this.txtConsignee.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtConsignee.Location = new System.Drawing.Point(80, 76);
            this.txtConsignee.Name = "txtConsignee";
            this.txtConsignee.ReadOnly = true;
            this.txtConsignee.Size = new System.Drawing.Size(164, 22);
            this.txtConsignee.TabIndex = 1;
            this.txtConsignee.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Delivery", 9F);
            this.label5.Location = new System.Drawing.Point(250, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ship Date:";
            // 
            // txtShipmentDate
            // 
            this.txtShipmentDate.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtShipmentDate.Location = new System.Drawing.Point(316, 50);
            this.txtShipmentDate.Name = "txtShipmentDate";
            this.txtShipmentDate.ReadOnly = true;
            this.txtShipmentDate.Size = new System.Drawing.Size(155, 22);
            this.txtShipmentDate.TabIndex = 1;
            this.txtShipmentDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Delivery", 9F);
            this.label6.Location = new System.Drawing.Point(269, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pieces:";
            // 
            // txtNumberOfPieces
            // 
            this.txtNumberOfPieces.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtNumberOfPieces.Location = new System.Drawing.Point(316, 76);
            this.txtNumberOfPieces.Name = "txtNumberOfPieces";
            this.txtNumberOfPieces.ReadOnly = true;
            this.txtNumberOfPieces.Size = new System.Drawing.Size(28, 22);
            this.txtNumberOfPieces.TabIndex = 1;
            this.txtNumberOfPieces.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(350, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Weight:";
            // 
            // txtShipmentWeight
            // 
            this.txtShipmentWeight.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtShipmentWeight.Location = new System.Drawing.Point(404, 76);
            this.txtShipmentWeight.Name = "txtShipmentWeight";
            this.txtShipmentWeight.ReadOnly = true;
            this.txtShipmentWeight.Size = new System.Drawing.Size(67, 22);
            this.txtShipmentWeight.TabIndex = 1;
            this.txtShipmentWeight.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Delivery", 9F);
            this.label8.Location = new System.Drawing.Point(477, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Last Checkpoint:";
            // 
            // txtShipmentLastCheckpoint
            // 
            this.txtShipmentLastCheckpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipmentLastCheckpoint.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtShipmentLastCheckpoint.Location = new System.Drawing.Point(576, 76);
            this.txtShipmentLastCheckpoint.Name = "txtShipmentLastCheckpoint";
            this.txtShipmentLastCheckpoint.ReadOnly = true;
            this.txtShipmentLastCheckpoint.Size = new System.Drawing.Size(157, 22);
            this.txtShipmentLastCheckpoint.TabIndex = 1;
            this.txtShipmentLastCheckpoint.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Delivery", 9F);
            this.label4.Location = new System.Drawing.Point(509, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reference:";
            // 
            // txtShipmentReference
            // 
            this.txtShipmentReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipmentReference.Font = new System.Drawing.Font("Delivery", 9F);
            this.txtShipmentReference.Location = new System.Drawing.Point(576, 50);
            this.txtShipmentReference.Name = "txtShipmentReference";
            this.txtShipmentReference.ReadOnly = true;
            this.txtShipmentReference.Size = new System.Drawing.Size(157, 22);
            this.txtShipmentReference.TabIndex = 1;
            this.txtShipmentReference.TabStop = false;
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRequest.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnViewRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewRequest.Location = new System.Drawing.Point(642, 19);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(41, 25);
            this.btnViewRequest.TabIndex = 4;
            this.btnViewRequest.TabStop = false;
            this.btnViewRequest.Text = "REQ";
            this.ToolTip1.SetToolTip(this.btnViewRequest, "View Request XML");
            this.btnViewRequest.UseVisualStyleBackColor = false;
            this.btnViewRequest.Click += new System.EventHandler(this.BtnViewRequest_Click);
            // 
            // btnViewResponse
            // 
            this.btnViewResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResponse.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnViewResponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewResponse.Location = new System.Drawing.Point(689, 19);
            this.btnViewResponse.Name = "btnViewResponse";
            this.btnViewResponse.Size = new System.Drawing.Size(44, 25);
            this.btnViewResponse.TabIndex = 5;
            this.btnViewResponse.TabStop = false;
            this.btnViewResponse.Text = "RESP";
            this.ToolTip1.SetToolTip(this.btnViewResponse, "View Response XML");
            this.btnViewResponse.UseVisualStyleBackColor = false;
            this.btnViewResponse.Click += new System.EventHandler(this.BtnViewResponse_Click);
            // 
            // dgvTrackingData
            // 
            this.dgvTrackingData.AllowUserToAddRows = false;
            this.dgvTrackingData.AllowUserToDeleteRows = false;
            this.dgvTrackingData.AllowUserToOrderColumns = true;
            this.dgvTrackingData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrackingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackingData.Location = new System.Drawing.Point(12, 102);
            this.dgvTrackingData.Name = "dgvTrackingData";
            this.dgvTrackingData.ReadOnly = true;
            this.dgvTrackingData.Size = new System.Drawing.Size(721, 318);
            this.dgvTrackingData.TabIndex = 3;
            // 
            // cmbTrackingType
            // 
            this.cmbTrackingType.Font = new System.Drawing.Font("Delivery", 9F);
            this.cmbTrackingType.FormattingEnabled = true;
            this.cmbTrackingType.Location = new System.Drawing.Point(369, 21);
            this.cmbTrackingType.Name = "cmbTrackingType";
            this.cmbTrackingType.Size = new System.Drawing.Size(121, 23);
            this.cmbTrackingType.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Delivery", 9F);
            this.label9.Location = new System.Drawing.Point(281, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tracking Type:";
            // 
            // BtnNextShipment
            // 
            this.BtnNextShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNextShipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.BtnNextShipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNextShipment.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.BtnNextShipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.BtnNextShipment.Location = new System.Drawing.Point(576, 20);
            this.BtnNextShipment.Name = "BtnNextShipment";
            this.BtnNextShipment.Size = new System.Drawing.Size(49, 25);
            this.BtnNextShipment.TabIndex = 4;
            this.BtnNextShipment.TabStop = false;
            this.BtnNextShipment.Text = "NEXT";
            this.BtnNextShipment.UseVisualStyleBackColor = false;
            this.BtnNextShipment.Click += new System.EventHandler(this.BtnNextShipment_Click);
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(744, 432);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbTrackingType);
            this.Controls.Add(this.dgvTrackingData);
            this.Controls.Add(this.btnViewResponse);
            this.Controls.Add(this.BtnNextShipment);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.btnTrack);
            this.Controls.Add(this.txtConsignee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShipmentReference);
            this.Controls.Add(this.txtShipmentLastCheckpoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShipmentWeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumberOfPieces);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtShipmentDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtShipper);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTrackingNumber);
            this.Controls.Add(this.label1);
            this.Name = "Track";
            this.Text = "Track";
            this.Load += new System.EventHandler(this.Track_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrackingNumber;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShipper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConsignee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShipmentDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumberOfPieces;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShipmentWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShipmentLastCheckpoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShipmentReference;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.Button btnViewResponse;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.DataGridView dgvTrackingData;
        private System.Windows.Forms.ComboBox cmbTrackingType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnNextShipment;
    }
}