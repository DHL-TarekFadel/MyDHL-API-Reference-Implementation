using System;
using System.Windows.Forms;

namespace GloWS_Test_App.REST
{
    public partial class JSONViewer : Form
    {
        private string _textToShow;

        public JSONViewer(string textToShow)
        {
            InitializeComponent();
            _textToShow = textToShow;
        }

        private void JSONViewer_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_textToShow)) return;

            txtXMLDisplay.Text = _textToShow.Replace("\n", Environment.NewLine);
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

        /// <summary>
        /// This is required because there is a bug in .NET which causes Ctrl+A to stop working for multiline textboxes.
        /// </summary>
        /// <param name="sender">Textbox that initialted the call</param>
        /// <param name="e">Event Arguemnts</param>
        private void TxtXMLDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
            e.Handled = true;
        }
    }
}
