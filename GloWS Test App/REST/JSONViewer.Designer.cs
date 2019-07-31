namespace MyDHLAPI_Test_App.REST
{
    partial class JSONViewer
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
            this.txtXMLDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtXMLDisplay
            // 
            this.txtXMLDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXMLDisplay.CausesValidation = false;
            this.txtXMLDisplay.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtXMLDisplay.HideSelection = false;
            this.txtXMLDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtXMLDisplay.MaxLength = 65535;
            this.txtXMLDisplay.Multiline = true;
            this.txtXMLDisplay.Name = "txtXMLDisplay";
            this.txtXMLDisplay.ReadOnly = true;
            this.txtXMLDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXMLDisplay.Size = new System.Drawing.Size(585, 539);
            this.txtXMLDisplay.TabIndex = 0;
            this.txtXMLDisplay.WordWrap = false;
            this.txtXMLDisplay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtXMLDisplay_KeyUp);
            // 
            // JSONViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(609, 563);
            this.Controls.Add(this.txtXMLDisplay);
            this.KeyPreview = true;
            this.Name = "JSONViewer";
            this.Text = "JSON Viewer";
            this.Load += new System.EventHandler(this.JSONViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXMLDisplay;
    }
}