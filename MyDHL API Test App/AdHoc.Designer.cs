namespace MyDHLAPI_Test_App
{
    partial class AdHoc
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
            this.txtSOAP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRunJSON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnRunSOAP = new System.Windows.Forms.Button();
            this.btnFromJSON = new System.Windows.Forms.Button();
            this.btnFromSOAP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSOAP
            // 
            this.txtSOAP.AcceptsReturn = true;
            this.txtSOAP.AcceptsTab = true;
            this.txtSOAP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSOAP.Enabled = false;
            this.txtSOAP.HideSelection = false;
            this.txtSOAP.Location = new System.Drawing.Point(12, 44);
            this.txtSOAP.Multiline = true;
            this.txtSOAP.Name = "txtSOAP";
            this.txtSOAP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSOAP.Size = new System.Drawing.Size(483, 394);
            this.txtSOAP.TabIndex = 1;
            this.txtSOAP.Visible = false;
            this.txtSOAP.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Delivery", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "SOAP Request";
            // 
            // btnRunJSON
            // 
            this.btnRunJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnRunJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnRunJSON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnRunJSON.Location = new System.Drawing.Point(920, 6);
            this.btnRunJSON.Name = "btnRunJSON";
            this.btnRunJSON.Size = new System.Drawing.Size(61, 35);
            this.btnRunJSON.TabIndex = 2;
            this.btnRunJSON.Text = "Run";
            this.btnRunJSON.UseVisualStyleBackColor = false;
            this.btnRunJSON.Click += new System.EventHandler(this.BtnRunJSON_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Delivery", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(677, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "JSON Request";
            // 
            // txtJSON
            // 
            this.txtJSON.AcceptsReturn = true;
            this.txtJSON.AcceptsTab = true;
            this.txtJSON.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtJSON.HideSelection = false;
            this.txtJSON.Location = new System.Drawing.Point(501, 44);
            this.txtJSON.Multiline = true;
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJSON.Size = new System.Drawing.Size(483, 394);
            this.txtJSON.TabIndex = 4;
            this.txtJSON.Visible = false;
            this.txtJSON.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Delivery", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1199, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.AcceptsTab = true;
            this.txtResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtResult.HideSelection = false;
            this.txtResult.Location = new System.Drawing.Point(990, 44);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(483, 394);
            this.txtResult.TabIndex = 6;
            this.txtResult.Visible = false;
            this.txtResult.WordWrap = false;
            // 
            // btnRunSOAP
            // 
            this.btnRunSOAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnRunSOAP.Enabled = false;
            this.btnRunSOAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunSOAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnRunSOAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnRunSOAP.Location = new System.Drawing.Point(434, 6);
            this.btnRunSOAP.Name = "btnRunSOAP";
            this.btnRunSOAP.Size = new System.Drawing.Size(61, 35);
            this.btnRunSOAP.TabIndex = 7;
            this.btnRunSOAP.Text = "Run";
            this.btnRunSOAP.UseVisualStyleBackColor = false;
            this.btnRunSOAP.Click += new System.EventHandler(this.BtnRunSOAP_Click);
            // 
            // btnFromJSON
            // 
            this.btnFromJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnFromJSON.Enabled = false;
            this.btnFromJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFromJSON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnFromJSON.Location = new System.Drawing.Point(350, 6);
            this.btnFromJSON.Name = "btnFromJSON";
            this.btnFromJSON.Size = new System.Drawing.Size(78, 35);
            this.btnFromJSON.TabIndex = 9;
            this.btnFromJSON.Text = "from JSON";
            this.btnFromJSON.UseVisualStyleBackColor = false;
            this.btnFromJSON.Click += new System.EventHandler(this.BtnFromJSON_Click);
            // 
            // btnFromSOAP
            // 
            this.btnFromSOAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnFromSOAP.Enabled = false;
            this.btnFromSOAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromSOAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFromSOAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnFromSOAP.Location = new System.Drawing.Point(836, 6);
            this.btnFromSOAP.Name = "btnFromSOAP";
            this.btnFromSOAP.Size = new System.Drawing.Size(78, 35);
            this.btnFromSOAP.TabIndex = 8;
            this.btnFromSOAP.Text = "from SOAP";
            this.btnFromSOAP.UseVisualStyleBackColor = false;
            this.btnFromSOAP.Click += new System.EventHandler(this.BtnFromSOAP_Click);
            // 
            // AdHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1477, 450);
            this.Controls.Add(this.btnFromJSON);
            this.Controls.Add(this.btnFromSOAP);
            this.Controls.Add(this.btnRunSOAP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJSON);
            this.Controls.Add(this.btnRunJSON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSOAP);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1493, 489);
            this.MinimumSize = new System.Drawing.Size(1493, 489);
            this.Name = "AdHoc";
            this.ShowIcon = false;
            this.Text = "Ad Hoc Request";
            this.Load += new System.EventHandler(this.AdHoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSOAP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunJSON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJSON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnRunSOAP;
        private System.Windows.Forms.Button btnFromJSON;
        private System.Windows.Forms.Button btnFromSOAP;
    }
}