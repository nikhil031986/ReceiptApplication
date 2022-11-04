using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin winfStartLogin = new frmLogin();
            winfStartLogin.ShowDialog();
            if (!string.IsNullOrEmpty(ClsUtil.currentUserInfo.UserName))
            {
                Application.Run(new frmRecipt());
            }
        }
    }
}
