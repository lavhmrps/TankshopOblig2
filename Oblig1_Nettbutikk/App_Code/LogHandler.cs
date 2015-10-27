using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Oblig1_Nettbutikk.App_Code
{
    public class LogHandler
    {

        private const string LOG_PATH = "~\\Logs";
        private const string LOG_FILE = "log.txt";

        static LogHandler() {

            var folder = HttpContext.Current.Server.MapPath(LOG_PATH);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

        }

        public static void WriteToLog(Exception e) {

            string logStr = "Error @ " + DateTime.Now.ToShortDateString().ToString() +
                " " + DateTime.Now.ToLongTimeString().ToString() + " --> " + e;

            WriteToLog(logStr);
        }


        private static void WriteToLog(string str) {

            string fullPath = HttpContext.Current.Server.MapPath(LOG_PATH) + "\\" + LOG_FILE;

            StreamWriter sw = new StreamWriter(fullPath, true);
            sw.WriteLine(str);
            sw.WriteLine();
            sw.WriteLine();

            sw.Flush();
            sw.Close();
          
        }    

    }
}