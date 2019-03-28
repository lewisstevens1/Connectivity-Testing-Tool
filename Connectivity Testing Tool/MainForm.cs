using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO.Compression;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Connectivity_Testing_Tool.Properties;

namespace Connectivity_Testing_Tool
{
    public partial class MainForm : Form
    {
        int _animation_index = 0;
        string _animation_text = "...";

        //  MAIN FORM
        public MainForm()
        {
            InitializeComponent();
        }

        // ENCRYPT THE STRING SO USER CANNOT ALTER DATA
        public static string EncryptString(string plainText)
        {
            try
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
            catch
            {
                return "CANNOT ENCRYPT";
            }
        }

       
        // MAIN FORM ON LOAD
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ONLY ALLOW IT TO BE RUN LOCALLY
            try
            {
                RegistryKey REGBASE = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey REGKEY = REGBASE.OpenSubKey(@"SOFTWARE\Microsoft\Virtual Machine\Guest\Parameters");

                string HOSTSTRING = (string)REGKEY.GetValue("HostName");
                string HOSTSTRINGREP = Regex.Replace(HOSTSTRING, "[0-9]", "");

                if (HOSTSTRINGREP == "BUNKER")
                {
                    MessageBox.Show("This cannot be run on the hosted desktop. Please run the tool from your local computer.");
                    Application.Exit();
                }
                
            } catch {}
        }

        private void ctt_timer_Tick(object sender, EventArgs e)
        {
            string CDATE = DateTime.Now.ToString("yyyy_MM_dd");
            string FILE_PATH = @Settings.Default.FILE_PATH;
            string TARGET_FILE1 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE1;
            string TARGET_FILE2 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE2;

            // CREATE DIRECTORY IF IT DOESN'T EXIST
            if (!File.Exists(FILE_PATH))
            {
                Directory.CreateDirectory(FILE_PATH);
            }

            // CREATES THE FILES IF IT DOESNT EXIST AND DISPOSE OF MEMORY SO IT CAN BE APPENDED TO
            if (!File.Exists(TARGET_FILE1))
            {
                File.Create(TARGET_FILE1).Dispose();
            }
            if (!File.Exists(TARGET_FILE2))
            {
                File.Create(TARGET_FILE2).Dispose();
            }


            var TASKS = new List<Task>();
            Ping PING_CLASS = new Ping();

            var task = PingAndUpdateAsync(PING_CLASS,"8.8.8.8","8.8.4.4");
            TASKS.Add(task);            
        }

        private void ctt_note_disconnection_Click(object sender, EventArgs e)
        {
            if (ctt_note_disconnection.Enabled)
            {
                string CDATE = DateTime.Now.ToString("yyyy_MM_dd");

                string FILE_PATH = @Settings.Default.FILE_PATH;
                string TARGET_FILE3 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE3;

                if (!File.Exists(TARGET_FILE3))
                {
                    File.Create(TARGET_FILE3).Dispose();
                }

                // NOTIFICATION OF DISCONNECTION
                string OUTPUT = DateTime.Now.ToString("yyyyMMddHHmmss") + ";^;0";
                OUTPUT = EncryptString(OUTPUT);

                using (StreamWriter STREAM = File.AppendText(TARGET_FILE3))
                {
                    STREAM.WriteLine(OUTPUT);
                    STREAM.Close();
                }

                Thread t = new Thread(new ThreadStart(ctt_note_disconnection_animation));
                t.Start();
            }
        }

        private void ctt_note_disconnection_animation()
        {            
            Thread.Sleep(50);
            if (ctt_note_disconnection.Enabled)
            {
                ctt_note_disconnection.Invoke(new Action(() =>
                {
                    ctt_note_disconnection.Text = "DISCONNECTION NOTED";
                    ctt_note_disconnection.Enabled = false;

                    Thread.Sleep(2000);

                    ctt_note_disconnection.Invoke(new Action(() =>
                    {
                        ctt_note_disconnection.Text = "NOTE DISCONNECTION";
                        ctt_note_disconnection.Enabled = true;
                    }));
                }));
            }
        }

        private void ctt_export_button_Click(object sender, EventArgs e)
        {
            string FILE_PATH = @Settings.Default.FILE_PATH;

            if (!File.Exists(FILE_PATH))
            {
                // CREATE NEW SAVEFILE DIALOGUE TO ONLY ALLOW COMPRESSION TYPES
                SaveFileDialog SAVE_FILE = new SaveFileDialog
                {
                    FileName = "CTT_OUTPUT.zip",
                    Filter = "Zip Files|*.zip"
                };

                // IF ALL OK, CREATE DIRECTORY WITH PATH
                if (SAVE_FILE.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(SAVE_FILE.FileName))
                    {
                        File.Delete(SAVE_FILE.FileName);
                    }

                    ZipFile.CreateFromDirectory(FILE_PATH, SAVE_FILE.FileName);
                    Directory.Delete(FILE_PATH,true);
                    Application.Exit();
                }
            }    
        }
               
        // MAIN FORM ON CLOSE
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
        }

        private void ctt_stats_timer_Tick(object sender, EventArgs e)
        {
            string CDATE = DateTime.Now.ToString("yyyy_MM_dd");

            string FILE_PATH = @Settings.Default.FILE_PATH;
            string TARGET_FILE2 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE2;

            // COMPUTER RESOURCES
            using (StreamWriter STREAM = File.AppendText(TARGET_FILE2))
            {
                string RETURNSTRING = "";
                const double BytesInMB = 1048576;

                // GET RAM USAGE
                ManagementObjectSearcher OSearch = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
                ManagementObjectCollection OResults = OSearch.Get();
                foreach (ManagementObject Result in OResults)
                {
                    double TOTAL_RAM;
                    TOTAL_RAM = Convert.ToDouble(Result["TotalVisibleMemorySize"]);
                    TOTAL_RAM = Math.Round((TOTAL_RAM / (1024 * 1024)), 2);

                    double FREE_RAM;
                    FREE_RAM = Convert.ToDouble(Result["FreePhysicalMemory"]);
                    FREE_RAM = Math.Round((FREE_RAM / (1024 * 1024)), 2); 

                    RETURNSTRING = FREE_RAM + ";" + TOTAL_RAM + ";";   
                }

                // GET CPU USAGE
                // THIS HAS TO START ON NEXTVALUE THEN IT NEEDS A DELAY UNTIL IT READS ITS NEXT VALUE.
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                object oldCpuVal = cpuCounter.NextValue();
                Thread.Sleep(2000);

                float newCpuVal = cpuCounter.NextValue();
                RETURNSTRING += Math.Round(newCpuVal,0) + ";";

                // GET DISK USAGE
                DriveInfo drive = new DriveInfo("C");
                if (drive.IsReady)
                {
                    RETURNSTRING += Math.Round((drive.AvailableFreeSpace / BytesInMB),0);
                }

                // OUTPUT
                RETURNSTRING = DateTime.Now.ToString("yyyyMMddHHmmss") + ";" + RETURNSTRING;
                RETURNSTRING = EncryptString(RETURNSTRING);
                
                STREAM.WriteLine(RETURNSTRING);
                STREAM.Close();

                // CLEAR MEMORY
                GC.Collect();
            }
        }

        private async Task PingAndUpdateAsync(Ping ping, string ip1,string ip2)
        {
            var reply = await ping.SendPingAsync(ip1, 500);
            var reply2 = await ping.SendPingAsync(ip2, 500);

            string CDATE = DateTime.Now.ToString("yyyy_MM_dd");

            string FILE_PATH = @Settings.Default.FILE_PATH;
            string TARGET_FILE1 = FILE_PATH + CDATE + "." + Settings.Default.TARGET_FILE1;

            string OUTPUT1 = "";
            string OUTPUT2 = "";
            if (reply.Status == IPStatus.Success)
            {
                OUTPUT1 += DateTime.Now.ToString("yyyyMMddHHmmss") + ";"+ ip1 + ";" + reply.RoundtripTime.ToString();
            }
            else
            {
                OUTPUT1 += DateTime.Now.ToString("yyyyMMddHHmmss") + ";"+ ip1 + ";0";
            }
            if (reply2.Status == IPStatus.Success)
            {
                OUTPUT2 += DateTime.Now.ToString("yyyyMMddHHmmss") + ";"+ ip2 + ";" + reply2.RoundtripTime.ToString();
            }
            else
            {
                OUTPUT2 += DateTime.Now.ToString("yyyyMMddHHmmss") + ";"+ ip2 + ";0";
            }

            OUTPUT1 = EncryptString(OUTPUT1);                
            OUTPUT2 = EncryptString(OUTPUT2);

            using (StreamWriter STREAM = File.AppendText(TARGET_FILE1))
            {              
                STREAM.WriteLine(OUTPUT1);
                STREAM.WriteLine(OUTPUT2);
                STREAM.Close();
            }          
        }

       
    }
}