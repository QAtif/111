using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BOLRecruitmentDocumentUploadingLibrary
{
    public class Logging
    {
        public static string GenerateDefaultLogFileName(string BaseFileName)
        {
            //Checks that already folder of this name exists or not
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\");
            }
            return AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\" + BaseFileName + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".log";
        }

        /// <summary>
        /// Pass in the fully qualified name of the log file you want to write to
        /// and the message to write
        /// </summary>
        /// <param name="LogPath"></param>
        /// <param name="Message"></param>
        public static void WriteToLog(string LogPath, string Message)
        {
            System.IO.StreamWriter s = null;
            try
            {
                s = System.IO.File.AppendText(LogPath);
                s.WriteLine(DateTime.Now + "\t" + Message);
                s.WriteLine();
                s.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            s = null;
        }

        /// <summary>
        /// Writes a message to the application event log
        /// /// </summary>
        /// <param name="Source">Source is the source of the message ususally you will want this to be the application name</param>
        /// <param name="Message">message to be written</param>
        /// <param name="EntryType">the entry type to use to categorize the message like for exmaple error or information</param>
        public static void WriteToEventLog(string Source, string Message, System.Diagnostics.EventLogEntryType EntryType)
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists(Source))
                {
                    System.Diagnostics.EventLog.CreateEventSource(Source, "Application");
                }
                System.Diagnostics.EventLog.WriteEntry(Source, Message, EntryType);
            }
            catch { }
        }
    }
}
