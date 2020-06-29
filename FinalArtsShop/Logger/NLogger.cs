using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinalArtsShop.Logger
{
    public static class NLogger
    {
        public static void Error(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }

        public static void Infor(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g Infor") + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }

    }
}