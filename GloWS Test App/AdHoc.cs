using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDHLAPI_Test_App
{
    public partial class AdHoc : Form
    {
        Scintilla soapTextbox;
        Scintilla jsonTextbox;
        Scintilla resultTextbox;

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        public AdHoc()
        {
            InitializeComponent();
        }

        private void AdHoc_Load(object sender, EventArgs e)
        {
            soapTextbox = new Scintilla();
            jsonTextbox = new Scintilla();
            resultTextbox = new Scintilla();

            ApplyTemplate(ref txtSOAP, ref soapTextbox);
            ApplyTemplate(ref txtJSON, ref jsonTextbox);
            ApplyTemplate(ref txtResult, ref resultTextbox);

            InitCodeEditor(ref soapTextbox);
            InitCodeEditor(ref jsonTextbox);
            InitCodeEditor(ref resultTextbox);

            this.Controls.Add(soapTextbox);
            this.Controls.Add(jsonTextbox);
            this.Controls.Add(resultTextbox);
        }

        private void ApplyTemplate(ref TextBox template, ref Scintilla txt)
        {
            txt.Size = template.Size;
            txt.Location = template.Location;
            txt.ReadOnly = template.ReadOnly;
            txt.Anchor = template.Anchor;
        }

        private void InitCodeEditor(ref Scintilla txt)
        {
            txt.WrapMode = WrapMode.None;
            txt.IndentationGuides = IndentView.LookBoth;

            var nums = txt.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        private void BtnFromJSON_Click(object sender, EventArgs e)
        {

        }

        private void BtnFromSOAP_Click(object sender, EventArgs e)
        {

        }

        private void BtnRunSOAP_Click(object sender, EventArgs e)
        {

        }

        private void BtnRunJSON_Click(object sender, EventArgs e)
        {

        }
    }
}
