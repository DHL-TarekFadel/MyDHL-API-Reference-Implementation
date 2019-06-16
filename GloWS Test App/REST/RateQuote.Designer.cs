namespace MyDHLAPI_Test_App.REST {
    partial class RateQuote {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGo = new System.Windows.Forms.Button();
            this.gbShipper = new System.Windows.Forms.GroupBox();
            this.txtShipperCountry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShipperUSState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShipperPostalCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShipperCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbShipment = new System.Windows.Forms.GroupBox();
            this.txtDeclaredCurrency = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ntxtHeight = new System.Windows.Forms.NumericUpDown();
            this.ntxtWidth = new System.Windows.Forms.NumericUpDown();
            this.ntxtLength = new System.Windows.Forms.NumericUpDown();
            this.ntxtDeclaredValue = new System.Windows.Forms.NumericUpDown();
            this.ntxtWeight = new System.Windows.Forms.NumericUpDown();
            this.cmbRequestCourier = new System.Windows.Forms.ComboBox();
            this.cmbUOM = new System.Windows.Forms.ComboBox();
            this.cmbDutiable = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblUOMHeight = new System.Windows.Forms.Label();
            this.lblUOMWidth = new System.Windows.Forms.Label();
            this.lblUOMLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUOMWeight = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbBilling = new System.Windows.Forms.GroupBox();
            this.cbxShowAllServices = new System.Windows.Forms.CheckBox();
            this.rbtnPayBilling = new System.Windows.Forms.RadioButton();
            this.rbtnPayShipper = new System.Windows.Forms.RadioButton();
            this.txtAccountBilling = new System.Windows.Forms.TextBox();
            this.txtAccountShipper = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbTermsOfTrade = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gbConsignee = new System.Windows.Forms.GroupBox();
            this.txtConsigneeCountry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConsigneeUSState = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConsigneePostalCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConsigneeCity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tvResult = new System.Windows.Forms.TreeView();
            this.label22 = new System.Windows.Forms.Label();
            this.btnViewRequest = new System.Windows.Forms.Button();
            this.btnViewResponse = new System.Windows.Forms.Button();
            this.gbShipper.SuspendLayout();
            this.gbShipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtDeclaredValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtWeight)).BeginInit();
            this.gbBilling.SuspendLayout();
            this.gbConsignee.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.AutoSize = true;
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(375, 14);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(50, 25);
            this.btnGo.TabIndex = 25;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // gbShipper
            // 
            this.gbShipper.Controls.Add(this.txtShipperCountry);
            this.gbShipper.Controls.Add(this.label5);
            this.gbShipper.Controls.Add(this.txtShipperUSState);
            this.gbShipper.Controls.Add(this.label4);
            this.gbShipper.Controls.Add(this.txtShipperPostalCode);
            this.gbShipper.Controls.Add(this.label3);
            this.gbShipper.Controls.Add(this.txtShipperCity);
            this.gbShipper.Controls.Add(this.label2);
            this.gbShipper.Location = new System.Drawing.Point(8, 8);
            this.gbShipper.Margin = new System.Windows.Forms.Padding(2);
            this.gbShipper.Name = "gbShipper";
            this.gbShipper.Padding = new System.Windows.Forms.Padding(2);
            this.gbShipper.Size = new System.Drawing.Size(196, 106);
            this.gbShipper.TabIndex = 3;
            this.gbShipper.TabStop = false;
            this.gbShipper.Text = "Shipper";
            // 
            // txtShipperCountry
            // 
            this.txtShipperCountry.Location = new System.Drawing.Point(74, 79);
            this.txtShipperCountry.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipperCountry.MaxLength = 2;
            this.txtShipperCountry.Name = "txtShipperCountry";
            this.txtShipperCountry.Size = new System.Drawing.Size(117, 20);
            this.txtShipperCountry.TabIndex = 4;
            this.txtShipperCountry.Text = "AE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Country:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipperUSState
            // 
            this.txtShipperUSState.Location = new System.Drawing.Point(74, 58);
            this.txtShipperUSState.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipperUSState.MaxLength = 2;
            this.txtShipperUSState.Name = "txtShipperUSState";
            this.txtShipperUSState.Size = new System.Drawing.Size(117, 20);
            this.txtShipperUSState.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "US State:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipperPostalCode
            // 
            this.txtShipperPostalCode.Location = new System.Drawing.Point(74, 37);
            this.txtShipperPostalCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipperPostalCode.MaxLength = 12;
            this.txtShipperPostalCode.Name = "txtShipperPostalCode";
            this.txtShipperPostalCode.Size = new System.Drawing.Size(117, 20);
            this.txtShipperPostalCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Postal Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipperCity
            // 
            this.txtShipperCity.Location = new System.Drawing.Point(74, 16);
            this.txtShipperCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtShipperCity.MaxLength = 35;
            this.txtShipperCity.Name = "txtShipperCity";
            this.txtShipperCity.Size = new System.Drawing.Size(117, 20);
            this.txtShipperCity.TabIndex = 1;
            this.txtShipperCity.Text = "DUBAI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "City:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbShipment
            // 
            this.gbShipment.Controls.Add(this.txtDeclaredCurrency);
            this.gbShipment.Controls.Add(this.label20);
            this.gbShipment.Controls.Add(this.ntxtHeight);
            this.gbShipment.Controls.Add(this.ntxtWidth);
            this.gbShipment.Controls.Add(this.ntxtLength);
            this.gbShipment.Controls.Add(this.ntxtDeclaredValue);
            this.gbShipment.Controls.Add(this.ntxtWeight);
            this.gbShipment.Controls.Add(this.cmbRequestCourier);
            this.gbShipment.Controls.Add(this.cmbUOM);
            this.gbShipment.Controls.Add(this.cmbDutiable);
            this.gbShipment.Controls.Add(this.label14);
            this.gbShipment.Controls.Add(this.label13);
            this.gbShipment.Controls.Add(this.label12);
            this.gbShipment.Controls.Add(this.lblUOMHeight);
            this.gbShipment.Controls.Add(this.lblUOMWidth);
            this.gbShipment.Controls.Add(this.lblUOMLength);
            this.gbShipment.Controls.Add(this.label1);
            this.gbShipment.Controls.Add(this.lblUOMWeight);
            this.gbShipment.Controls.Add(this.label19);
            this.gbShipment.Controls.Add(this.label15);
            this.gbShipment.Controls.Add(this.label10);
            this.gbShipment.Controls.Add(this.label11);
            this.gbShipment.Location = new System.Drawing.Point(208, 8);
            this.gbShipment.Margin = new System.Windows.Forms.Padding(2);
            this.gbShipment.Name = "gbShipment";
            this.gbShipment.Padding = new System.Windows.Forms.Padding(2);
            this.gbShipment.Size = new System.Drawing.Size(163, 216);
            this.gbShipment.TabIndex = 3;
            this.gbShipment.TabStop = false;
            this.gbShipment.Text = "Shipment/Package";
            // 
            // txtDeclaredCurrency
            // 
            this.txtDeclaredCurrency.Location = new System.Drawing.Point(66, 84);
            this.txtDeclaredCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeclaredCurrency.MaxLength = 3;
            this.txtDeclaredCurrency.Name = "txtDeclaredCurrency";
            this.txtDeclaredCurrency.Size = new System.Drawing.Size(94, 20);
            this.txtDeclaredCurrency.TabIndex = 13;
            this.txtDeclaredCurrency.Text = "AED";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 86);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Currency:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ntxtHeight
            // 
            this.ntxtHeight.Location = new System.Drawing.Point(66, 190);
            this.ntxtHeight.Margin = new System.Windows.Forms.Padding(2);
            this.ntxtHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ntxtHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntxtHeight.Name = "ntxtHeight";
            this.ntxtHeight.Size = new System.Drawing.Size(67, 20);
            this.ntxtHeight.TabIndex = 18;
            this.ntxtHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ntxtWidth
            // 
            this.ntxtWidth.Location = new System.Drawing.Point(66, 169);
            this.ntxtWidth.Margin = new System.Windows.Forms.Padding(2);
            this.ntxtWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ntxtWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntxtWidth.Name = "ntxtWidth";
            this.ntxtWidth.Size = new System.Drawing.Size(67, 20);
            this.ntxtWidth.TabIndex = 17;
            this.ntxtWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ntxtLength
            // 
            this.ntxtLength.Location = new System.Drawing.Point(66, 148);
            this.ntxtLength.Margin = new System.Windows.Forms.Padding(2);
            this.ntxtLength.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ntxtLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ntxtLength.Name = "ntxtLength";
            this.ntxtLength.Size = new System.Drawing.Size(67, 20);
            this.ntxtLength.TabIndex = 16;
            this.ntxtLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ntxtDeclaredValue
            // 
            this.ntxtDeclaredValue.DecimalPlaces = 2;
            this.ntxtDeclaredValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ntxtDeclaredValue.Location = new System.Drawing.Point(66, 62);
            this.ntxtDeclaredValue.Margin = new System.Windows.Forms.Padding(2);
            this.ntxtDeclaredValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ntxtDeclaredValue.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ntxtDeclaredValue.Name = "ntxtDeclaredValue";
            this.ntxtDeclaredValue.Size = new System.Drawing.Size(93, 20);
            this.ntxtDeclaredValue.TabIndex = 11;
            this.ntxtDeclaredValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // ntxtWeight
            // 
            this.ntxtWeight.DecimalPlaces = 2;
            this.ntxtWeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ntxtWeight.Location = new System.Drawing.Point(66, 127);
            this.ntxtWeight.Margin = new System.Windows.Forms.Padding(2);
            this.ntxtWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ntxtWeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ntxtWeight.Name = "ntxtWeight";
            this.ntxtWeight.Size = new System.Drawing.Size(67, 20);
            this.ntxtWeight.TabIndex = 15;
            this.ntxtWeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // cmbRequestCourier
            // 
            this.cmbRequestCourier.Items.AddRange(new object[] {
            "Request",
            "Scheduled"});
            this.cmbRequestCourier.Location = new System.Drawing.Point(66, 16);
            this.cmbRequestCourier.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRequestCourier.Name = "cmbRequestCourier";
            this.cmbRequestCourier.Size = new System.Drawing.Size(94, 21);
            this.cmbRequestCourier.TabIndex = 9;
            // 
            // cmbUOM
            // 
            this.cmbUOM.Items.AddRange(new object[] {
            "SI (KG, CM)",
            "SU (LB, IN)"});
            this.cmbUOM.Location = new System.Drawing.Point(66, 105);
            this.cmbUOM.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUOM.Name = "cmbUOM";
            this.cmbUOM.Size = new System.Drawing.Size(94, 21);
            this.cmbUOM.TabIndex = 14;
            this.cmbUOM.SelectedIndexChanged += new System.EventHandler(this.CmbUOM_SelectedIndexChanged);
            // 
            // cmbDutiable
            // 
            this.cmbDutiable.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbDutiable.Location = new System.Drawing.Point(66, 39);
            this.cmbDutiable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDutiable.Name = "cmbDutiable";
            this.cmbDutiable.Size = new System.Drawing.Size(94, 21);
            this.cmbDutiable.TabIndex = 10;
            this.cmbDutiable.SelectedIndexChanged += new System.EventHandler(this.CmbDutiable_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 192);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Height:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 170);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Width:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 150);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Length:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUOMHeight
            // 
            this.lblUOMHeight.Location = new System.Drawing.Point(137, 192);
            this.lblUOMHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUOMHeight.Name = "lblUOMHeight";
            this.lblUOMHeight.Size = new System.Drawing.Size(22, 13);
            this.lblUOMHeight.TabIndex = 1;
            this.lblUOMHeight.Text = "cm";
            this.lblUOMHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUOMWidth
            // 
            this.lblUOMWidth.Location = new System.Drawing.Point(137, 170);
            this.lblUOMWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUOMWidth.Name = "lblUOMWidth";
            this.lblUOMWidth.Size = new System.Drawing.Size(22, 13);
            this.lblUOMWidth.TabIndex = 1;
            this.lblUOMWidth.Text = "cm";
            this.lblUOMWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUOMLength
            // 
            this.lblUOMLength.Location = new System.Drawing.Point(137, 150);
            this.lblUOMLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUOMLength.Name = "lblUOMLength";
            this.lblUOMLength.Size = new System.Drawing.Size(22, 13);
            this.lblUOMLength.TabIndex = 1;
            this.lblUOMLength.Text = "cm";
            this.lblUOMLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pickup:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUOMWeight
            // 
            this.lblUOMWeight.Location = new System.Drawing.Point(137, 129);
            this.lblUOMWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUOMWeight.Name = "lblUOMWeight";
            this.lblUOMWeight.Size = new System.Drawing.Size(22, 13);
            this.lblUOMWeight.TabIndex = 1;
            this.lblUOMWeight.Text = "KG";
            this.lblUOMWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 64);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Value:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 107);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "UOM:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 129);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Weight:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Document:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBilling
            // 
            this.gbBilling.Controls.Add(this.cbxShowAllServices);
            this.gbBilling.Controls.Add(this.rbtnPayBilling);
            this.gbBilling.Controls.Add(this.rbtnPayShipper);
            this.gbBilling.Controls.Add(this.txtAccountBilling);
            this.gbBilling.Controls.Add(this.txtAccountShipper);
            this.gbBilling.Controls.Add(this.label18);
            this.gbBilling.Controls.Add(this.label17);
            this.gbBilling.Controls.Add(this.label16);
            this.gbBilling.Controls.Add(this.cmbTermsOfTrade);
            this.gbBilling.Controls.Add(this.label21);
            this.gbBilling.Location = new System.Drawing.Point(8, 228);
            this.gbBilling.Margin = new System.Windows.Forms.Padding(2);
            this.gbBilling.Name = "gbBilling";
            this.gbBilling.Padding = new System.Windows.Forms.Padding(2);
            this.gbBilling.Size = new System.Drawing.Size(363, 69);
            this.gbBilling.TabIndex = 3;
            this.gbBilling.TabStop = false;
            this.gbBilling.Text = "Billing";
            // 
            // cbxShowAllServices
            // 
            this.cbxShowAllServices.AutoSize = true;
            this.cbxShowAllServices.Location = new System.Drawing.Point(247, 46);
            this.cbxShowAllServices.Margin = new System.Windows.Forms.Padding(2);
            this.cbxShowAllServices.Name = "cbxShowAllServices";
            this.cbxShowAllServices.Size = new System.Drawing.Size(111, 17);
            this.cbxShowAllServices.TabIndex = 24;
            this.cbxShowAllServices.Text = "Show All Services";
            this.cbxShowAllServices.UseVisualStyleBackColor = true;
            // 
            // rbtnPayBilling
            // 
            this.rbtnPayBilling.AutoSize = true;
            this.rbtnPayBilling.Location = new System.Drawing.Point(173, 46);
            this.rbtnPayBilling.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPayBilling.Name = "rbtnPayBilling";
            this.rbtnPayBilling.Size = new System.Drawing.Size(43, 17);
            this.rbtnPayBilling.TabIndex = 22;
            this.rbtnPayBilling.Text = "Pay";
            this.rbtnPayBilling.UseVisualStyleBackColor = true;
            // 
            // rbtnPayShipper
            // 
            this.rbtnPayShipper.AutoSize = true;
            this.rbtnPayShipper.Checked = true;
            this.rbtnPayShipper.Location = new System.Drawing.Point(173, 25);
            this.rbtnPayShipper.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPayShipper.Name = "rbtnPayShipper";
            this.rbtnPayShipper.Size = new System.Drawing.Size(43, 17);
            this.rbtnPayShipper.TabIndex = 21;
            this.rbtnPayShipper.TabStop = true;
            this.rbtnPayShipper.Text = "Pay";
            this.rbtnPayShipper.UseVisualStyleBackColor = true;
            // 
            // txtAccountBilling
            // 
            this.txtAccountBilling.Location = new System.Drawing.Point(53, 45);
            this.txtAccountBilling.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountBilling.MaxLength = 35;
            this.txtAccountBilling.Name = "txtAccountBilling";
            this.txtAccountBilling.Size = new System.Drawing.Size(117, 20);
            this.txtAccountBilling.TabIndex = 20;
            this.txtAccountBilling.Text = "961187381";
            // 
            // txtAccountShipper
            // 
            this.txtAccountShipper.Location = new System.Drawing.Point(53, 25);
            this.txtAccountShipper.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountShipper.MaxLength = 35;
            this.txtAccountShipper.Name = "txtAccountShipper";
            this.txtAccountShipper.Size = new System.Drawing.Size(117, 20);
            this.txtAccountShipper.TabIndex = 19;
            this.txtAccountShipper.Text = "961187381";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 47);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Billing:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(59, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Account #";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Shipper:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTermsOfTrade
            // 
            this.cmbTermsOfTrade.Items.AddRange(new object[] {
            "SI (KG, CM)",
            "SU (LB, IN)"});
            this.cmbTermsOfTrade.Location = new System.Drawing.Point(247, 23);
            this.cmbTermsOfTrade.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTermsOfTrade.Name = "cmbTermsOfTrade";
            this.cmbTermsOfTrade.Size = new System.Drawing.Size(94, 21);
            this.cmbTermsOfTrade.TabIndex = 23;
            this.cmbTermsOfTrade.SelectedIndexChanged += new System.EventHandler(this.CmbUOM_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(253, 9);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Terms of Trade:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbConsignee
            // 
            this.gbConsignee.Controls.Add(this.txtConsigneeCountry);
            this.gbConsignee.Controls.Add(this.label6);
            this.gbConsignee.Controls.Add(this.txtConsigneeUSState);
            this.gbConsignee.Controls.Add(this.label7);
            this.gbConsignee.Controls.Add(this.txtConsigneePostalCode);
            this.gbConsignee.Controls.Add(this.label8);
            this.gbConsignee.Controls.Add(this.txtConsigneeCity);
            this.gbConsignee.Controls.Add(this.label9);
            this.gbConsignee.Location = new System.Drawing.Point(8, 118);
            this.gbConsignee.Margin = new System.Windows.Forms.Padding(2);
            this.gbConsignee.Name = "gbConsignee";
            this.gbConsignee.Padding = new System.Windows.Forms.Padding(2);
            this.gbConsignee.Size = new System.Drawing.Size(196, 107);
            this.gbConsignee.TabIndex = 3;
            this.gbConsignee.TabStop = false;
            this.gbConsignee.Text = "Recipient/Consignee";
            // 
            // txtConsigneeCountry
            // 
            this.txtConsigneeCountry.Location = new System.Drawing.Point(74, 79);
            this.txtConsigneeCountry.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsigneeCountry.MaxLength = 2;
            this.txtConsigneeCountry.Name = "txtConsigneeCountry";
            this.txtConsigneeCountry.Size = new System.Drawing.Size(117, 20);
            this.txtConsigneeCountry.TabIndex = 8;
            this.txtConsigneeCountry.Text = "SA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Country:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsigneeUSState
            // 
            this.txtConsigneeUSState.Location = new System.Drawing.Point(74, 58);
            this.txtConsigneeUSState.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsigneeUSState.MaxLength = 2;
            this.txtConsigneeUSState.Name = "txtConsigneeUSState";
            this.txtConsigneeUSState.Size = new System.Drawing.Size(117, 20);
            this.txtConsigneeUSState.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "US State:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsigneePostalCode
            // 
            this.txtConsigneePostalCode.Location = new System.Drawing.Point(74, 37);
            this.txtConsigneePostalCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsigneePostalCode.MaxLength = 12;
            this.txtConsigneePostalCode.Name = "txtConsigneePostalCode";
            this.txtConsigneePostalCode.Size = new System.Drawing.Size(117, 20);
            this.txtConsigneePostalCode.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Postal Code:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsigneeCity
            // 
            this.txtConsigneeCity.Location = new System.Drawing.Point(74, 16);
            this.txtConsigneeCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsigneeCity.MaxLength = 35;
            this.txtConsigneeCity.Name = "txtConsigneeCity";
            this.txtConsigneeCity.Size = new System.Drawing.Size(117, 20);
            this.txtConsigneeCity.TabIndex = 5;
            this.txtConsigneeCity.Text = "RIYADH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "City:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvResult
            // 
            this.tvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvResult.Location = new System.Drawing.Point(375, 70);
            this.tvResult.Margin = new System.Windows.Forms.Padding(2);
            this.tvResult.Name = "tvResult";
            this.tvResult.Size = new System.Drawing.Size(186, 228);
            this.tvResult.TabIndex = 4;
            this.tvResult.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(375, 49);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Result:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRequest.AutoSize = true;
            this.btnViewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewRequest.Location = new System.Drawing.Point(510, 14);
            this.btnViewRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(50, 25);
            this.btnViewRequest.TabIndex = 25;
            this.btnViewRequest.TabStop = false;
            this.btnViewRequest.Text = "Req";
            this.btnViewRequest.UseVisualStyleBackColor = false;
            this.btnViewRequest.Click += new System.EventHandler(this.BtnViewRequest_Click);
            // 
            // btnViewResponse
            // 
            this.btnViewResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResponse.AutoSize = true;
            this.btnViewResponse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.btnViewResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnViewResponse.Location = new System.Drawing.Point(510, 39);
            this.btnViewResponse.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewResponse.Name = "btnViewResponse";
            this.btnViewResponse.Size = new System.Drawing.Size(50, 25);
            this.btnViewResponse.TabIndex = 26;
            this.btnViewResponse.TabStop = false;
            this.btnViewResponse.Text = "Resp";
            this.btnViewResponse.UseVisualStyleBackColor = false;
            this.btnViewResponse.Click += new System.EventHandler(this.BtnViewResponse_Click);
            // 
            // RateQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(568, 305);
            this.Controls.Add(this.tvResult);
            this.Controls.Add(this.gbBilling);
            this.Controls.Add(this.gbShipment);
            this.Controls.Add(this.gbConsignee);
            this.Controls.Add(this.gbShipper);
            this.Controls.Add(this.btnViewResponse);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label22);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RateQuote";
            this.Text = "[REST] Rate Quote";
            this.Load += new System.EventHandler(this.RateQuote_Load);
            this.gbShipper.ResumeLayout(false);
            this.gbShipper.PerformLayout();
            this.gbShipment.ResumeLayout(false);
            this.gbShipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtDeclaredValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtWeight)).EndInit();
            this.gbBilling.ResumeLayout(false);
            this.gbBilling.PerformLayout();
            this.gbConsignee.ResumeLayout(false);
            this.gbConsignee.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox gbShipper;
        private System.Windows.Forms.TextBox txtShipperUSState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShipperPostalCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShipperCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbShipment;
        private System.Windows.Forms.GroupBox gbBilling;
        private System.Windows.Forms.TextBox txtShipperCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ntxtHeight;
        private System.Windows.Forms.NumericUpDown ntxtWidth;
        private System.Windows.Forms.NumericUpDown ntxtLength;
        private System.Windows.Forms.NumericUpDown ntxtWeight;
        private System.Windows.Forms.ComboBox cmbDutiable;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblUOMHeight;
        private System.Windows.Forms.Label lblUOMWidth;
        private System.Windows.Forms.Label lblUOMLength;
        private System.Windows.Forms.Label lblUOMWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbConsignee;
        private System.Windows.Forms.TextBox txtConsigneeCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConsigneeUSState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConsigneePostalCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConsigneeCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbUOM;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbtnPayBilling;
        private System.Windows.Forms.RadioButton rbtnPayShipper;
        private System.Windows.Forms.TextBox txtAccountBilling;
        private System.Windows.Forms.TextBox txtAccountShipper;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbRequestCourier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeclaredCurrency;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown ntxtDeclaredValue;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbTermsOfTrade;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TreeView tvResult;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnViewRequest;
        private System.Windows.Forms.Button btnViewResponse;
        private System.Windows.Forms.CheckBox cbxShowAllServices;
    }
}