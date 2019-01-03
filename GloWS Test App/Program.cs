using System;
using System.Windows.Forms;
using System.IO;

namespace GloWS_Test_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool exitApplication = false;
            if (File.Exists("credentials.txt"))
            {
                string[] credentials = File.ReadAllLines("credentials.txt");
                if (credentials.Length < 2)
                {
                    MessageBox.Show($"The credentials file doesn't appear to have credentials, please ensure that line 1 has the username and line 2 has the password.{Environment.NewLine}{Environment.NewLine}The application will now exit."
                                , "Invalid Credentials File"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);

                    exitApplication = true;
                }
                else
                {
                    Common.username = credentials[0];
                    Common.password = credentials[1];
                }
            }
            else
            {
                MessageBox.Show($"Please ensure that there is a credentials.txt file in the same directory as the application.{Environment.NewLine}{Environment.NewLine}The application will now exit."
                                , "Missing Credentials File"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);

                exitApplication = true;
            }
            
            if (!exitApplication)
            {
                if (File.Exists("defaults.json"))
                {
                    Common.ParseDefaultsJSON(File.ReadAllText("defaults.json"));
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainMenu());
            }
        }
    }
}
