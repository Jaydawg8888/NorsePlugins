using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorseCore
{
    public sealed class NorseLogging
    {
        #region Constructor
        public NorseLogging(ManualLogSource manualLogSource)
        {
            LogSource = manualLogSource;
        }
        #endregion

        #region Functions
        public void CreateConsoleLog(string message, LogType logType = LogType.Info)
        {
            string combinedMessage = $"{LogSource.SourceName}: {message}";

            if (logType == LogType.Info)
                LogSource.LogInfo(combinedMessage);
            else if (logType == LogType.Debug)
                LogSource.LogDebug(combinedMessage);
            else if (logType == LogType.Warning)
                LogSource.LogWarning(combinedMessage);
            else if (logType == LogType.Error)
                LogSource.LogError(combinedMessage);
            else
                LogSource.LogFatal(combinedMessage);
        }
        #endregion

        #region Properties

        public enum LogType
        {
            Info,
            Debug,
            Warning,
            Error,
            Fatal
        }
        #endregion

        #region Fields      
        private static ManualLogSource LogSource { get; set; }
        #endregion
    }
}
