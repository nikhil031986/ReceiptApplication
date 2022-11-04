using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptLog
{
    public class clsLog
    {
        public string filePath { get; set; }
        public  string fileName { get; set; }
        public  string logFile { get; set; }

        public enum logType
        {
            Error = 0,
            Info = 1,
            Debug = 2
        }
        public clsLog()
        {

        }
        private volatile static clsLog singleTonObject;
        private static object lockingObject = new object();
        public static clsLog InstanceCreation()
        {
            if (singleTonObject == null)
            {
                lock (lockingObject)
                {
                    if (singleTonObject == null)
                    {
                        singleTonObject = new clsLog();
                    }
                }
            }
            return singleTonObject;
        }
        public  void CreateLogFile()
        {
            try
            {
                fileName = "ReceiptLog_" + DateTime.Now.ToString("dd_MM_yyyy")+".txt";
                if (!System.IO.File.Exists(filePath + fileName))
                {
                    System.IO.File.Create(filePath + fileName);
                }
                logFile = filePath + fileName;
            }
            catch
            {

            }
        }
        public  void InsertLog(string message, logType lgtype, string ClassName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(logFile) && System.IO.File.Exists(logFile))
                {
                    List<string> strError = new List<string>();
                    strError.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:tt") + " " + "Message Type:" + lgtype.ToString() + ", Message : " + message + " , Class Name:" + ClassName);
                    System.IO.File.AppendAllLines(logFile, strError);
                }
            }
            catch
            {
            }
        }

    }
}
