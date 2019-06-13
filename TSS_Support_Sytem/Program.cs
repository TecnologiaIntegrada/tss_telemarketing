using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSS_Support_Sytem.Model;
using TSS_Support_Sytem.Utils;

namespace TSS_Support_Sytem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppSettings appSettings = AppSettings.FromJson(Archive.ReadFile(PathUtils.ToCurrentLocation(@"\Data\Settings.json")));
            Application.Run(new frmLogin(appSettings));
        }
    }
}
