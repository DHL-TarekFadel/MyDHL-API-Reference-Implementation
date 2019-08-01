namespace MyDHLAPI_Test_App.REST
{
    partial class ePOD
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
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.txtAWBNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPODType = new System.Windows.Forms.ComboBox();
            this.btnViewResponse = new System.Windows.Forms.Button();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(113, 95);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(101, 16);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumber.TabIndex = 1;
            // 
            // txtAWBNumber
            // 
            this.txtAWBNumber.Location = new System.Drawing.Point(101, 42);
            this.txtAWBNumber.Name = "txtAWBNumber";
            this.txtAWBNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAWBNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "AWB #:";
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ePOD Type:";
            // 
            // cmbPODType
            // 
            this.cmbPODType.FormattingEnabled = true;
            this.cmbPODType.Items.AddRange(new object[] {
            "Summary",
            "Detailed",
            "Table Summary",
            "Table Detailed"});
            this.cmbPODType.Location = new System.Drawing.Point(101, 68);
            this.cmbPODType.Name = "cmbPODType";
            this.cmbPODType.Size = new System.Drawing.Size(100, 21);
            this.cmbPODType.TabIndex = 3;
            // 
            // btnViewResponse
            // 
            this.btnViewResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResponse.AutoSize = true;
            this.btnViewResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewResponse.Location = new System.Drawing.Point(243, 37);
            this.btnViewResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewResponse.Name = "btnViewResponse";
            this.btnViewResponse.Size = new System.Drawing.Size(50, 25);
            this.btnViewResponse.TabIndex = 28;
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
            this.btnViewRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewRequest.Location = new System.Drawing.Point(243, 12);
            this.btnViewRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(50, 25);
            this.btnViewRequest.TabIndex = 27;
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
            this.txtResult.Location = new System.Drawing.Point(12, 124);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(277, 139);
            this.txtResult.TabIndex = 29;
            this.txtResult.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Messages:";
            // 
            // ePOD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(301, 275);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnViewResponse);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.cmbPODType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAWBNumber);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.btnGo);
            this.Name = "ePOD";
            this.Text = "ePOD";
            this.Load += new System.EventHandler(this.EPOD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.TextBox txtAWBNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPODType;
        private System.Windows.Forms.Button btnViewResponse;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
    }
}