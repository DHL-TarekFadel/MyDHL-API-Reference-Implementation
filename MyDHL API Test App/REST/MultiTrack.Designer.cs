namespace MyDHLAPI_Test_App.REST
{
    partial class MultiTrack
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAWBNumber = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.dgvShipmentDetails = new System.Windows.Forms.DataGridView();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.btnShowReponse = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AWB Number(s):";
            // 
            // txtAWBNumber
            // 
            this.txtAWBNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAWBNumber.Location = new System.Drawing.Point(11, 24);
            this.txtAWBNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtAWBNumber.Multiline = true;
            this.txtAWBNumber.Name = "txtAWBNumber";
            this.txtAWBNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAWBNumber.Size = new System.Drawing.Size(111, 341);
            this.txtAWBNumber.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(124, 8);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 13);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "Result:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Delivery Cd Light", 11F);
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(11, 369);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(111, 36);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "RETRIEVE DATA";
            this.btnGo.UseVisualStyleBackColor = false;
            // 
            // dgvShipmentDetails
            // 
            this.dgvShipmentDetails.AllowUserToAddRows = false;
            this.dgvShipmentDetails.AllowUserToDeleteRows = false;
            this.dgvShipmentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShipmentDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShipmentDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShipmentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipmentDetails.Location = new System.Drawing.Point(127, 24);
            this.dgvShipmentDetails.Name = "dgvShipmentDetails";
            this.dgvShipmentDetails.ReadOnly = true;
            this.dgvShipmentDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShipmentDetails.Size = new System.Drawing.Size(898, 341);
            this.dgvShipmentDetails.TabIndex = 10;
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewRequest.AutoSize = true;
            this.btnViewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRequest.Font = new System.Drawing.Font("Delivery Cd Light", 11F);
            this.btnViewRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewRequest.Location = new System.Drawing.Point(127, 370);
            this.btnViewRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(76, 35);
            this.btnViewRequest.TabIndex = 26;
            this.btnViewRequest.TabStop = false;
            this.btnViewRequest.Text = "REQUEST";
            this.btnViewRequest.UseVisualStyleBackColor = false;
            // 
            // btnShowReponse
            // 
            this.btnShowReponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowReponse.AutoSize = true;
            this.btnShowReponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnShowReponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReponse.Font = new System.Drawing.Font("Delivery Cd Light", 11F);
            this.btnShowReponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnShowReponse.Location = new System.Drawing.Point(207, 370);
            this.btnShowReponse.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowReponse.Name = "btnShowReponse";
            this.btnShowReponse.Size = new System.Drawing.Size(83, 35);
            this.btnShowReponse.TabIndex = 27;
            this.btnShowReponse.TabStop = false;
            this.btnShowReponse.Text = "RESPONSE";
            this.btnShowReponse.UseVisualStyleBackColor = false;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToClipboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnCopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyToClipboard.Font = new System.Drawing.Font("Delivery Cd Light", 11F);
            this.btnCopyToClipboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnCopyToClipboard.Location = new System.Drawing.Point(879, 369);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(146, 36);
            this.btnCopyToClipboard.TabIndex = 9;
            this.btnCopyToClipboard.Text = "COPY TO CLIPBOARD";
            this.btnCopyToClipboard.UseVisualStyleBackColor = false;
            // 
            // MultiTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1037, 416);
            this.Controls.Add(this.btnShowReponse);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.dgvShipmentDetails);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtAWBNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Delivery", 8.25F);
            this.Name = "MultiTrack";
            this.Text = "MultiTrack";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtAWBNumber;
        internal System.Windows.Forms.Label lblResult;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.DataGridView dgvShipmentDetails;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.Button btnShowReponse;
        internal System.Windows.Forms.Button btnCopyToClipboard;
    }
}