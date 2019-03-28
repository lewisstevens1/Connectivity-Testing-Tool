using System;
using System.Windows.Forms;

namespace Connectivity_Testing_Tool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splashscreen());
        }
    }
}
