using System;
using System.IO;
using System.Threading.Tasks;

namespace Nettbutikk
{
    public class Logger
    {
        public const string LOG_PATH = "~\\Logs";
        public const string LOG_FILE = "log.txt";

        private static StreamWriter LogFileStream;

        public static void Initialize(string logPath)
        {
            LogFileStream = new StreamWriter(logPath + "\\" + LOG_FILE, true);
            LogFileStream.AutoFlush = true;
        }

        public static void WriteToLog(Exception e)
        {
            Task.Run(() =>
            {
                if (e == null)
                {
                    WriteToLog("Error @ " + DateTime.Now.ToShortDateString().ToString() +
                    " " + DateTime.Now.ToLongTimeString().ToString() + " --> " + "NO EXCEPTION INFORMATION");
                }
                else
                {
                    WriteToLog("Error @ " + DateTime.Now.ToShortDateString().ToString() +
                    " " + DateTime.Now.ToLongTimeString().ToString() + " --> " + e);
                }
            });
        }


        public static void WriteToLog(string str)
        {
            Task.Run(() =>
            {
                LogFileStream.WriteLine(str);
                LogFileStream.WriteLine();

                LogFileStream.Flush();
            });
        }
    }
}