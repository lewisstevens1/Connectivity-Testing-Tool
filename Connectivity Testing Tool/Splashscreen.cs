using System;
using System.Windows.Forms;

namespace Connectivity_Testing_Tool
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent(); 
        }

        // BUTTON TO LAUNCH SPEEDTEST FORM
        private void ctt_mainform_launch_Click(object sender, EventArgs e)
        {
            // SHOW SPEEDTEST FORM
            SpeedTest SpeedTest = new SpeedTest();
            SpeedTest.Show();
            Hide();
        }

        // SPLASHSCREEN ON LOAD
        private void Splashscreen_Load(object sender, EventArgs e)
        {
        }

        // MAIN FORM ON CLOSE
        private void Splashscreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            for (int i = 0; i <= Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].Close();
            }
            */

            Application.Exit();
        }
    }
}
