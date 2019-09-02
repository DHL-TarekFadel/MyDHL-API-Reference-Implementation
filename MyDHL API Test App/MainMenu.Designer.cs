namespace MyDHLAPI_Test_App
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnSOAP_Track = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnSOAP_Ship = new System.Windows.Forms.Button();
            this.btnSOAP_EPOD = new System.Windows.Forms.Button();
            this.btnSwitchMode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnREST_Track = new System.Windows.Forms.Button();
            this.btnREST_Ship = new System.Windows.Forms.Button();
            this.btnREST_ePOD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnREST_RateQuery = new System.Windows.Forms.Button();
            this.btnAdHoc = new System.Windows.Forms.Button();
            this.btnREST_CreatePickup = new System.Windows.Forms.Button();
            this.btnREST_DeletePickup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSOAP_Track
            // 
            this.btnSOAP_Track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnSOAP_Track.Enabled = false;
            this.btnSOAP_Track.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSOAP_Track.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnSOAP_Track.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSOAP_Track.Location = new System.Drawing.Point(36, 253);
            this.btnSOAP_Track.Name = "btnSOAP_Track";
            this.btnSOAP_Track.Size = new System.Drawing.Size(99, 35);
            this.btnSOAP_Track.TabIndex = 2;
            this.btnSOAP_Track.Text = "TRACK";
            this.btnSOAP_Track.UseVisualStyleBackColor = false;
            this.btnSOAP_Track.Click += new System.EventHandler(this.BtnSOAP_Track_Click);
            // 
            // lblMode
            // 
            this.lblMode.Font = new System.Drawing.Font("Delivery", 11F);
            this.lblMode.Location = new System.Drawing.Point(51, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(203, 18);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Sandpit";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSOAP_Ship
            // 
            this.btnSOAP_Ship.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnSOAP_Ship.Enabled = false;
            this.btnSOAP_Ship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSOAP_Ship.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnSOAP_Ship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSOAP_Ship.Location = new System.Drawing.Point(36, 171);
            this.btnSOAP_Ship.Name = "btnSOAP_Ship";
            this.btnSOAP_Ship.Size = new System.Drawing.Size(99, 35);
            this.btnSOAP_Ship.TabIndex = 3;
            this.btnSOAP_Ship.Text = "SHIP";
            this.btnSOAP_Ship.UseVisualStyleBackColor = false;
            this.btnSOAP_Ship.Click += new System.EventHandler(this.BtnSOAP_Ship_Click);
            // 
            // btnSOAP_EPOD
            // 
            this.btnSOAP_EPOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnSOAP_EPOD.Enabled = false;
            this.btnSOAP_EPOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSOAP_EPOD.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnSOAP_EPOD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSOAP_EPOD.Location = new System.Drawing.Point(36, 294);
            this.btnSOAP_EPOD.Name = "btnSOAP_EPOD";
            this.btnSOAP_EPOD.Size = new System.Drawing.Size(99, 35);
            this.btnSOAP_EPOD.TabIndex = 4;
            this.btnSOAP_EPOD.Text = "ePOD";
            this.btnSOAP_EPOD.UseVisualStyleBackColor = false;
            this.btnSOAP_EPOD.Click += new System.EventHandler(this.BtnSOAP_EPOD_Click);
            // 
            // btnSwitchMode
            // 
            this.btnSwitchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnSwitchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchMode.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnSwitchMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSwitchMode.Location = new System.Drawing.Point(104, 54);
            this.btnSwitchMode.Name = "btnSwitchMode";
            this.btnSwitchMode.Size = new System.Drawing.Size(99, 35);
            this.btnSwitchMode.TabIndex = 1;
            this.btnSwitchMode.Text = "Switch";
            this.btnSwitchMode.UseVisualStyleBackColor = false;
            this.btnSwitchMode.Click += new System.EventHandler(this.BtnSwitchMode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Delivery", 8F);
            this.label2.Location = new System.Drawing.Point(106, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "You are working in";
            // 
            // btnREST_Track
            // 
            this.btnREST_Track.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_Track.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_Track.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnREST_Track.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_Track.Location = new System.Drawing.Point(172, 294);
            this.btnREST_Track.Name = "btnREST_Track";
            this.btnREST_Track.Size = new System.Drawing.Size(99, 35);
            this.btnREST_Track.TabIndex = 5;
            this.btnREST_Track.Text = "TRACK";
            this.btnREST_Track.UseVisualStyleBackColor = false;
            this.btnREST_Track.Click += new System.EventHandler(this.BtnREST_Track_Click);
            // 
            // btnREST_Ship
            // 
            this.btnREST_Ship.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_Ship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_Ship.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnREST_Ship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_Ship.Location = new System.Drawing.Point(172, 171);
            this.btnREST_Ship.Name = "btnREST_Ship";
            this.btnREST_Ship.Size = new System.Drawing.Size(99, 35);
            this.btnREST_Ship.TabIndex = 7;
            this.btnREST_Ship.Text = "SHIP";
            this.btnREST_Ship.UseVisualStyleBackColor = false;
            this.btnREST_Ship.Click += new System.EventHandler(this.BtnREST_Ship_Click);
            // 
            // btnREST_ePOD
            // 
            this.btnREST_ePOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_ePOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_ePOD.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnREST_ePOD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_ePOD.Location = new System.Drawing.Point(172, 335);
            this.btnREST_ePOD.Name = "btnREST_ePOD";
            this.btnREST_ePOD.Size = new System.Drawing.Size(99, 35);
            this.btnREST_ePOD.TabIndex = 8;
            this.btnREST_ePOD.Text = "ePOD";
            this.btnREST_ePOD.UseVisualStyleBackColor = false;
            this.btnREST_ePOD.Click += new System.EventHandler(this.BtnREST_ePOD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Delivery", 9F);
            this.label1.Location = new System.Drawing.Point(67, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "SOAP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Delivery", 9F);
            this.label3.Location = new System.Drawing.Point(203, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "REST";
            // 
            // btnREST_RateQuery
            // 
            this.btnREST_RateQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_RateQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_RateQuery.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnREST_RateQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_RateQuery.Location = new System.Drawing.Point(172, 130);
            this.btnREST_RateQuery.Name = "btnREST_RateQuery";
            this.btnREST_RateQuery.Size = new System.Drawing.Size(99, 35);
            this.btnREST_RateQuery.TabIndex = 6;
            this.btnREST_RateQuery.Text = "RATING";
            this.btnREST_RateQuery.UseVisualStyleBackColor = false;
            this.btnREST_RateQuery.Click += new System.EventHandler(this.BtnREST_RateQuery_Click);
            // 
            // btnAdHoc
            // 
            this.btnAdHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnAdHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdHoc.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnAdHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnAdHoc.Location = new System.Drawing.Point(104, 376);
            this.btnAdHoc.Name = "btnAdHoc";
            this.btnAdHoc.Size = new System.Drawing.Size(99, 35);
            this.btnAdHoc.TabIndex = 9;
            this.btnAdHoc.Text = "AD-HOC";
            this.btnAdHoc.UseVisualStyleBackColor = false;
            this.btnAdHoc.Click += new System.EventHandler(this.BtnAdHoc_Click);
            // 
            // btnREST_CreatePickup
            // 
            this.btnREST_CreatePickup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_CreatePickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_CreatePickup.Font = new System.Drawing.Font("Delivery Cd Light", 14F);
            this.btnREST_CreatePickup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_CreatePickup.Location = new System.Drawing.Point(172, 212);
            this.btnREST_CreatePickup.Name = "btnREST_CreatePickup";
            this.btnREST_CreatePickup.Size = new System.Drawing.Size(99, 35);
            this.btnREST_CreatePickup.TabIndex = 10;
            this.btnREST_CreatePickup.Text = "PICKUP";
            this.btnREST_CreatePickup.UseVisualStyleBackColor = false;
            this.btnREST_CreatePickup.Click += new System.EventHandler(this.BtnREST_CreatePickup_Click);
            // 
            // btnREST_DeletePickup
            // 
            this.btnREST_DeletePickup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnREST_DeletePickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREST_DeletePickup.Font = new System.Drawing.Font("Delivery Cd Light", 10F);
            this.btnREST_DeletePickup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnREST_DeletePickup.Location = new System.Drawing.Point(172, 253);
            this.btnREST_DeletePickup.Name = "btnREST_DeletePickup";
            this.btnREST_DeletePickup.Size = new System.Drawing.Size(99, 35);
            this.btnREST_DeletePickup.TabIndex = 10;
            this.btnREST_DeletePickup.Text = "DEL  PICKUP";
            this.btnREST_DeletePickup.UseVisualStyleBackColor = false;
            this.btnREST_DeletePickup.Click += new System.EventHandler(this.BtnREST_DeletePickup_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(306, 423);
            this.Controls.Add(this.btnREST_DeletePickup);
            this.Controls.Add(this.btnREST_CreatePickup);
            this.Controls.Add(this.btnAdHoc);
            this.Controls.Add(this.btnREST_RateQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnSwitchMode);
            this.Controls.Add(this.btnREST_ePOD);
            this.Controls.Add(this.btnSOAP_EPOD);
            this.Controls.Add(this.btnREST_Ship);
            this.Controls.Add(this.btnSOAP_Ship);
            this.Controls.Add(this.btnREST_Track);
            this.Controls.Add(this.btnSOAP_Track);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "MyDHL API Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSOAP_Track;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnSOAP_Ship;
        private System.Windows.Forms.Button btnSOAP_EPOD;
        private System.Windows.Forms.Button btnSwitchMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnREST_Track;
        private System.Windows.Forms.Button btnREST_Ship;
        private System.Windows.Forms.Button btnREST_ePOD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnREST_RateQuery;
        private System.Windows.Forms.Button btnAdHoc;
        private System.Windows.Forms.Button btnREST_CreatePickup;
        private System.Windows.Forms.Button btnREST_DeletePickup;
    }
}

