using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDataAccess
{
    internal class clsConfigrationSettings
    {
        public static string ConnectionString = "Server =.;Database = Online_Store ;User ID = sa;Password = sa123456;TrustServerCertificate=True;";
        public static string AppName = "Online_Store App";

        public static void _LogErorr(Exception ex)
        {
            if (!EventLog.SourceExists(ConfigurationManager.AppSettings["AppName"]))
            {
                EventLog.CreateEventSource(ConfigurationManager.AppSettings["AppName"], "Application");
            }
            EventLog.WriteEntry(ConfigurationManager.AppSettings["AppName"], $"An Error Occured : {ex.Message}", EventLogEntryType.Error);

        }
    }
}
