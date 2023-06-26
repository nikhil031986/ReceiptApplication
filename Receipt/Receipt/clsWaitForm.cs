using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Receipt
{
    internal static class clsWaitForm
    {
        private static frmwait _frmwait;
        private static Thread _waitThread;

        public static void ShowWaitForm()
        {
            _waitThread = new Thread(new ThreadStart(LodingProcess));
            _waitThread.Start();
        }
        public static void CloseWaitForm()
        {
            System.Threading.Thread.Sleep(500);
            if (_frmwait != null)
            {
                _frmwait.BeginInvoke(new System.Threading.ThreadStart(_frmwait.closeWait));
                _frmwait = null;
                _waitThread= null;
            }
        }

        private static void LodingProcess()
        {
            _frmwait = new frmwait();
            _frmwait.ShowDialog();
        }
    }
}
