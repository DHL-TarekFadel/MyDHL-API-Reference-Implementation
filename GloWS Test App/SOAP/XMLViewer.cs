using System;
using System.Windows.Forms;

namespace MyDHLAPI_Test_App.SOAP
{
    public partial class XMLViewer : Form
    {
        private string _textToShow;

        public XMLViewer(string textToShow)
        {
            InitializeComponent();
            _textToShow = textToShow;
        }

        private void XMLViewer_Load(object sender, EventArgs e)
        {
            txtXMLDisplay.Text = _textToShow;
            txtXMLDisplay.Select(0, 0);
        }

        /// <summary>
        /// Enabled the "Esc" key to close the form (but not affect anything else).
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
