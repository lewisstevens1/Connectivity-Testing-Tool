using Connectivity_Testing_Tool.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Connectivity_Testing_Tool
{
    public partial class SpeedTest : Form
    {
        Process sProcess = null;

        // ENCRYPT THE STRING SO USER CANNOT ALTER DATA
        public static string EncryptString(string plainText)
        {
            int ENC_KEYSIDE = Settings.Default.ENC_KEYSIDE;
            string ENV_VECTOR = Settings.Default.ENV_VECTOR;
            string ENCRYPTION_PASSWORD = Settings.Default.ENCRYPTION_PASSWORD;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(ENV_VECTOR);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(ENCRYPTION_PASSWORD, null);
            byte[] keyBytes = password.GetBytes(ENC_KEYSIDE / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        public SpeedTest()
        {
            InitializeComponent();
        }

        private void speedtest_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sProcess = Process.Start(Settings.Default.SPEEDTEST_URL);
        }

        private void speedtest_submit_Click(object sender, EventArgs e)
        {
            string CDATE = DateTime.Now.ToString("yyyy_MM_dd");

            string FILE_PATH = @Settings.Default.FILE_PATH;
            string TARGET_FILE4 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE4;

            string input = speedtest_input.Text;
            if (input.Contains(Settings.Default.SPEEDTEST_URL + "/result")) {

                // CREATE DIRECTORY IF IT DOESN'T EXIST
                if (!File.Exists(FILE_PATH))
                {
                    Directory.CreateDirectory(FILE_PATH);
                }

                // CREATES THE FILES IF IT DOESNT EXIST AND DISPOSE OF MEMORY SO IT CAN BE APPENDED TO
                if (!File.Exists(TARGET_FILE4))
                {
                    File.Create(TARGET_FILE4).Dispose();
                }

                var OUTPUT = DateTime.Now.ToString("yyyyMMddHHmmss") + ";" + input;
                OUTPUT = EncryptString(OUTPUT);

                using (StreamWriter STREAM = File.AppendText(TARGET_FILE4))
                {
                    STREAM.WriteLine(OUTPUT);
                    STREAM.Close();
                }

                // SHOW MAIN FORM
                MainForm MainForm = new MainForm();

                try
                {
                    sProcess.Kill();
                }
                catch { }

                MainForm.Show();
                Hide();

            } else {
                MessageBox.Show("The submitted data is not valid. Please ensure you copy the link after the speedtest from "+ Settings.Default.SPEEDTEST_URL + ".");
            }
        }

        private void speedtest_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                sProcess.Kill();
            }
            catch {}

            Application.Exit();
        }
    }
}
