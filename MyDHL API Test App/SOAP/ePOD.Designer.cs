namespace MyDHLAPI_Test_App.SOAP
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.txtAWBNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPODType = new System.Windows.Forms.ComboBox();
            this.cbxInternalFlag = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(72, 124);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(101, 16);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumber.TabIndex = 2;
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
            this.label2.Location = new System.Drawing.Point(35, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "AWB #:";
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
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
            this.cmbPODType.TabIndex = 4;
            // 
            // cbxInternalFlag
            // 
            this.cbxInternalFlag.AutoSize = true;
            this.cbxInternalFlag.Location = new System.Drawing.Point(76, 98);
            this.cbxInternalFlag.Name = "cbxInternalFlag";
            this.cbxInternalFlag.Size = new System.Drawing.Size(67, 17);
            this.cbxInternalFlag.TabIndex = 5;
            this.cbxInternalFlag.Text = "Internal?";
            this.cbxInternalFlag.UseVisualStyleBackColor = true;
            // 
            // ePOD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 202);
            this.Controls.Add(this.cbxInternalFlag);
            this.Controls.Add(this.cmbPODType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAWBNumber);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Name = "ePOD";
            this.Text = "ePOD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.TextBox txtAWBNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPODType;
        private System.Windows.Forms.CheckBox cbxInternalFlag;
    }
}