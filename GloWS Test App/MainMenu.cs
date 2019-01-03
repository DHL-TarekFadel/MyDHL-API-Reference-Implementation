using System;
using System.Drawing;
using System.Windows.Forms;

namespace GloWS_Test_App
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnSwitchMode_Click(object sender, EventArgs e)
        {
            if (Common.IsProduction)
            {
                Common.IsProduction = false;
                lblMode.Text = "Sandpit";
                lblMode.Font = new Font(lblMode.Font, FontStyle.Regular);
            }
            else
            {
                Common.IsProduction = true;
                lblMode.Text = "## PRODUCTION ##";
                lblMode.Font = new Font(lblMode.Font, FontStyle.Bold);
            }
        }

        private void BtnSOAP_Track_Click(object sender, EventArgs e)
        {
            Form frm = new SOAP.Track();
            frm.Show();
        }

        private void BtnSOAP_Ship_Click(object sender, EventArgs e)
        {
            Form frm = new SOAP.Ship();
            frm.Show();
        }

        private void BtnSOAP_EPOD_Click(object sender, EventArgs e)
        {
            Form frm = new SOAP.ePOD();
            frm.Show();
        }

        private void BtnREST_Track_Click(object sender, EventArgs e)
        {
            Form frm = new REST.Track();
            frm.Show();
        }

        private void BtnREST_RateQuery_Click(object sender, EventArgs e) {
            Form frm = new REST.RateQuote();
            frm.Show();
        }

        private void BtnREST_ePOD_Click(object sender, EventArgs e) {
            Form frm = new REST.ePOD();
            frm.Show();
        }

        private void BtnREST_Ship_Click(object sender, EventArgs e)
        {
            Form frm = new REST.Ship();
            frm.Show();
        }
    }
}
