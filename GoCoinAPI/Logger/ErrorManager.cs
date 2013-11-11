using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Logger
{
    /// <summary>
    /// Holds the Instance Of ErrorManager
    /// <remarks></remarks>
    /// </summary>
    public class ErrorManager
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="type"></param>
        public ErrorManager(string type)
        {
            //Logger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Logs an Error in Windows Event logs.
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(string _goCoinAPI, Exception _ex)
        {
            //Logger.Error(ex);
            if (!EventLog.SourceExists(_goCoinAPI))
                EventLog.CreateEventSource(_goCoinAPI, "Application");

            EventLog.WriteEntry(_goCoinAPI, _ex.Message, EventLogEntryType.Error);
        }

        /// <summary>
        /// To log error in log file.
        /// </summary>
        /// <param name="message"></param>
        public void LogMessage(string message)
        {
            string _strAppName = "GoCoinAPI";
            if (!EventLog.SourceExists(_strAppName))
                EventLog.CreateEventSource(_strAppName, "Application");

            EventLog.WriteEntry(_strAppName, message, EventLogEntryType.Information);
        }
    }
}