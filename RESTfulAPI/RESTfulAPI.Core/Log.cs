// =======================================================
// Author: Davain Pablo Edwards
// Email:  core8@gmx.net
// Web:    
// =======================================================

using System;
using System.IO;

namespace RESTfulAPI.Core
{
    public class Log
    {

        /// <summary>
        /// dpe
        /// 
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="w"></param>
        public static void Logging(string logMessage, TextWriter w, string errorGuid)
        {
            //string errorGuid = String.Format(Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16));

            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine(" error guid:" + " " + errorGuid);
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
            w.Close();
            w.Dispose();
        }


        public static string _errorGuid;

        public string ErrorGuid
        {
            get { return _errorGuid; }
            set { _errorGuid = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="r"></param>
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
