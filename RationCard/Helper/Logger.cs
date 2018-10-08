using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using log4net;
using log4net.Config;
using RationCard.Model;

namespace RationCard.Helper
{
    public static class Logger
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Logger));
        private static Dictionary<string, string> _errorLogsForDb = new Dictionary<string, string>();
        private static Timer _timerThread;
        private static int _period = 5000;

        static Logger()
        {
            BasicConfigurator.Configure();
            DOMConfigurator.Configure();
            //logger.Debug("Here is a debug log.");
            //logger.Info("... and an Info log.");
            //logger.Warn("... and a warning.");
            //logger.Error("... and an error.");
            //logger.Fatal("... and a fatal error.")

            _timerThread = new System.Threading.Timer((o) =>
            {
                // Stop the timer;
                _timerThread.Change(-1, -1);

                // Process your data
                LogErrorIntoDb();

                // start timer again (BeginTime, Interval)
                _timerThread.Change(_period, _period);
            }, null, 0, _period);
        }
        public static void LogError(Exception ex, string additionalMsg = "")
        {
            string successMsg = string.Empty;
            string msgToLogShort = ex.Message + Environment.NewLine + additionalMsg;
            string msgToLogLong = "Message: " + ex.Message + "InnerException: " + ex.InnerException + "StackTrace: " + ex.StackTrace + Environment.NewLine + additionalMsg;

            _errorLogsForDb.Add(DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss.fff"), msgToLogLong);
            EmailHelper.SendErrorMail(msgToLogLong);
            SmsHelper.NotifyAdmin(msgToLogShort, out successMsg);
            _logger.Error(msgToLogLong);
        }        
        public static void LogErrorIntoDb()
        {
            try
            {
                if (_errorLogsForDb.Count > 0)
                {
                    DataContractSerializer serializer = new DataContractSerializer(_errorLogsForDb.GetType());

                    StringWriter sw = new StringWriter();
                    using (XmlTextWriter writer = new NoNamespaceXmlWriter(sw))
                    {
                        // add formatting so the XML is easy to read in the log
                        writer.Formatting = Formatting.Indented;

                        serializer.WriteObject(writer, _errorLogsForDb);

                        writer.Flush();
                    }
                    string logXml = sw.ToString();

                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter { ParameterName = "@distId", SqlDbType = SqlDbType.VarChar, Value = User.DistId });
                    sqlParams.Add(new SqlParameter { ParameterName = "@logText", SqlDbType = SqlDbType.Xml, Value = logXml });
                    sqlParams.Add(new SqlParameter { ParameterName = "@macId", SqlDbType = SqlDbType.VarChar, Value = Network.GetActiveMACAddress() });
                    sqlParams.Add(new SqlParameter { ParameterName = "@action", SqlDbType = SqlDbType.VarChar, Value = "ADD" });

                    DataSet ds = ConnectionManager.Exec("Sp_Logger", sqlParams);
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        _errorLogsForDb.Clear();
                    }
                }
            }
            catch(Exception ex)
            {
                EmailHelper.SendErrorMail(ex);
            }
        }
        public static void LogError(string ex)
        {
            _errorLogsForDb.Add(DateTime.Parse(DateTime.Now.ToString()).ToString("MM-dd-yyyy HH:mm:ss"), ex);
            EmailHelper.SendErrorMail(ex);
            _logger.Error(ex);
        }
        public static void LogInfo(string ex)
        {
            _logger.Info(ex);
        }
    }
}
