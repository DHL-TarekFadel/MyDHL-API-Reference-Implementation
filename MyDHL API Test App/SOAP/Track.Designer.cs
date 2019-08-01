namespace MyDHLAPI_Test_App.SOAP
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "AWB/Piece ID";
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Location = new System.Drawing.Point(289, 21);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(167, 20);
            this.txtTrackingNumber.TabIndex = 1;
            // 
            // btnTrack
            // 
            this.btnTrack.Font = new System.Drawing.Font("Frutiger", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.Location = new System.Drawing.Point(462, 19);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(78, 23);
            this.btnTrack.TabIndex = 2;
            this.btnTrack.Text = "TRACK";
            this.btnTrack.UseVisualStyleBackColor = true;
            this.btnTrack.Click += new System.EventHandler(this.BtnTrack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shipper";
            // 
            // txtShipper
            // 
            this.txtShipper.Location = new System.Drawing.Point(80, 50);
            this.txtShipper.Name = "txtShipper";
            this.txtShipper.ReadOnly = true;
            this.txtShipper.Size = new System.Drawing.Size(164, 20);
            this.txtShipper.TabIndex = 1;
            this.txtShipper.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Consignee";
            // 
            // txtConsignee
            // 
            this.txtConsignee.Location = new System.Drawing.Point(80, 76);
            this.txtConsignee.Name = "txtConsignee";
            this.txtConsignee.ReadOnly = true;
            this.txtConsignee.Size = new System.Drawing.Size(164, 20);
            this.txtConsignee.TabIndex = 1;
            this.txtConsignee.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ship Date";
            // 
            // txtShipmentDate
            // 
            this.txtShipmentDate.Location = new System.Drawing.Point(313, 50);
            this.txtShipmentDate.Name = "txtShipmentDate";
            this.txtShipmentDate.ReadOnly = true;
            this.txtShipmentDate.Size = new System.Drawing.Size(152, 20);
            this.txtShipmentDate.TabIndex = 1;
            this.txtShipmentDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pieces";
            // 
            // txtNumberOfPieces
            // 
            this.txtNumberOfPieces.Location = new System.Drawing.Point(313, 76);
            this.txtNumberOfPieces.Name = "txtNumberOfPieces";
            this.txtNumberOfPieces.ReadOnly = true;
            this.txtNumberOfPieces.Size = new System.Drawing.Size(47, 20);
            this.txtNumberOfPieces.TabIndex = 1;
            this.txtNumberOfPieces.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(366, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Weight";
            // 
            // txtShipmentWeight
            // 
            this.txtShipmentWeight.Location = new System.Drawing.Point(417, 76);
            this.txtShipmentWeight.Name = "txtShipmentWeight";
            this.txtShipmentWeight.ReadOnly = true;
            this.txtShipmentWeight.Size = new System.Drawing.Size(48, 20);
            this.txtShipmentWeight.TabIndex = 1;
            this.txtShipmentWeight.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(471, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Last Checkpoint";
            // 
            // txtShipmentLastCheckpoint
            // 
            this.txtShipmentLastCheckpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipmentLastCheckpoint.Location = new System.Drawing.Point(567, 76);
            this.txtShipmentLastCheckpoint.Name = "txtShipmentLastCheckpoint";
            this.txtShipmentLastCheckpoint.ReadOnly = true;
            this.txtShipmentLastCheckpoint.Size = new System.Drawing.Size(164, 20);
            this.txtShipmentLastCheckpoint.TabIndex = 1;
            this.txtShipmentLastCheckpoint.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Frutiger", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(504, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reference";
            // 
            // txtShipmentReference
            // 
            this.txtShipmentReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipmentReference.Location = new System.Drawing.Point(568, 50);
            this.txtShipmentReference.Name = "txtShipmentReference";
            this.txtShipmentReference.ReadOnly = true;
            this.txtShipmentReference.Size = new System.Drawing.Size(164, 20);
            this.txtShipmentReference.TabIndex = 1;
            this.txtShipmentReference.TabStop = false;
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRequest.Font = new System.Drawing.Font("Frutiger", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewRequest.Location = new System.Drawing.Point(642, 19);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(41, 23);
            this.btnViewRequest.TabIndex = 2;
            this.btnViewRequest.TabStop = false;
            this.btnViewRequest.Text = "REQ";
            this.ToolTip1.SetToolTip(this.btnViewRequest, "View Request XML");
            this.btnViewRequest.UseVisualStyleBackColor = true;
            this.btnViewRequest.Click += new System.EventHandler(this.BtnViewRequest_Click);
            // 
            // btnViewResponse
            // 
            this.btnViewResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResponse.Font = new System.Drawing.Font("Frutiger", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResponse.Location = new System.Drawing.Point(689, 19);
            this.btnViewResponse.Name = "btnViewResponse";
            this.btnViewResponse.Size = new System.Drawing.Size(44, 23);
            this.btnViewResponse.TabIndex = 2;
            this.btnViewResponse.TabStop = false;
            this.btnViewResponse.Text = "RESP";
            this.ToolTip1.SetToolTip(this.btnViewResponse, "View Response XML");
            this.btnViewResponse.UseVisualStyleBackColor = true;
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
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(744, 432);
            this.Controls.Add(this.dgvTrackingData);
            this.Controls.Add(this.btnViewResponse);
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
    }
}