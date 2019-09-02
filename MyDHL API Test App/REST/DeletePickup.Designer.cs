namespace MyDHLAPI_Test_App.REST
{
    partial class DeletePickup
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPickupCountry = new System.Windows.Forms.TextBox();
            this.txtRequestorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.btnViewResponse = new System.Windows.Forms.Button();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPickupRequestNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpPickupDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Delivery Cd Light", 11F);
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(231, 94);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(62, 45);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // txtPickupCountry
            // 
            this.txtPickupCountry.Font = new System.Drawing.Font("Delivery", 8F);
            this.txtPickupCountry.Location = new System.Drawing.Point(100, 44);
            this.txtPickupCountry.MaxLength = 2;
            this.txtPickupCountry.Name = "txtPickupCountry";
            this.txtPickupCountry.Size = new System.Drawing.Size(31, 21);
            this.txtPickupCountry.TabIndex = 2;
            // 
            // txtRequestorName
            // 
            this.txtRequestorName.Font = new System.Drawing.Font("Delivery", 8F);
            this.txtRequestorName.Location = new System.Drawing.Point(100, 71);
            this.txtRequestorName.MaxLength = 45;
            this.txtRequestorName.Name = "txtRequestorName";
            this.txtRequestorName.Size = new System.Drawing.Size(100, 21);
            this.txtRequestorName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Delivery", 8F);
            this.label2.Location = new System.Drawing.Point(27, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pickup Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Delivery", 8F);
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pickup Country:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Delivery", 8F);
            this.label4.Location = new System.Drawing.Point(48, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbReason
            // 
            this.cmbReason.Font = new System.Drawing.Font("Delivery", 8F);
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "Summary",
            "Detailed",
            "Table Summary",
            "Table Detailed"});
            this.cmbReason.Location = new System.Drawing.Point(100, 125);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(100, 21);
            this.cmbReason.TabIndex = 5;
            // 
            // btnViewResponse
            // 
            this.btnViewResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResponse.AutoSize = true;
            this.btnViewResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResponse.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnViewResponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewResponse.Location = new System.Drawing.Point(243, 44);
            this.btnViewResponse.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewResponse.Name = "btnViewResponse";
            this.btnViewResponse.Size = new System.Drawing.Size(50, 29);
            this.btnViewResponse.TabIndex = 21;
            this.btnViewResponse.TabStop = false;
            this.btnViewResponse.Text = "Resp";
            this.btnViewResponse.UseVisualStyleBackColor = false;
            this.btnViewResponse.Click += new System.EventHandler(this.BtnViewResponse_Click);
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRequest.AutoSize = true;
            this.btnViewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRequest.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnViewRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewRequest.Location = new System.Drawing.Point(243, 12);
            this.btnViewRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(50, 29);
            this.btnViewRequest.TabIndex = 20;
            this.btnViewRequest.TabStop = false;
            this.btnViewRequest.Text = "Req";
            this.btnViewRequest.UseVisualStyleBackColor = false;
            this.btnViewRequest.Click += new System.EventHandler(this.BtnViewRequest_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.HideSelection = false;
            this.txtResult.Location = new System.Drawing.Point(12, 169);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(281, 128);
            this.txtResult.TabIndex = 30;
            this.txtResult.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Messages:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Delivery", 8F);
            this.label5.Location = new System.Drawing.Point(34, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Requestor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPickupRequestNumber
            // 
            this.txtPickupRequestNumber.Font = new System.Drawing.Font("Delivery", 8F);
            this.txtPickupRequestNumber.Location = new System.Drawing.Point(100, 98);
            this.txtPickupRequestNumber.MaxLength = 20;
            this.txtPickupRequestNumber.Name = "txtPickupRequestNumber";
            this.txtPickupRequestNumber.Size = new System.Drawing.Size(100, 21);
            this.txtPickupRequestNumber.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Delivery", 8F);
            this.label6.Location = new System.Drawing.Point(36, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Request #:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPickupDate.Font = new System.Drawing.Font("Delivery", 8F);
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickupDate.Location = new System.Drawing.Point(100, 17);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.Size = new System.Drawing.Size(100, 21);
            this.dtpPickupDate.TabIndex = 1;
            // 
            // DeletePickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(301, 309);
            this.Controls.Add(this.dtpPickupDate);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnViewResponse);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPickupRequestNumber);
            this.Controls.Add(this.txtRequestorName);
            this.Controls.Add(this.txtPickupCountry);
            this.Controls.Add(this.btnGo);
            this.Name = "DeletePickup";
            this.Text = "Delete Pickup";
            this.Load += new System.EventHandler(this.DeletePickup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtPickupCountry;
        private System.Windows.Forms.TextBox txtRequestorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Button btnViewResponse;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPickupRequestNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
    }
}