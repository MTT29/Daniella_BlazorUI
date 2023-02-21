namespace Daniella_BlazorUI.Services.LoggerService
{
    /*
     * a fájnévtartalmazza a dátumot és vizsgáljuk meg hogy ha  a legrébbei fájl már létezik akkor ne kezdjünk újat de ha  már a dátum változott azóta akkor igen
     *
     *
     *
     *
     *
     */
    public enum LogLevel
    {
        Debug,
        Info,
        Error,
        Warning
    }
    public class LogToFileService : ILogToFileService
    {
        private readonly string defaultPath = "Log";


        private  string logFilePath;

        public LogToFileService()
        {
           
        }

        private void LogMessage(LogLevel level, string message)
        {
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultPath + " " + DateTime.Now.Date.ToString("yyyy'-'MM'-'dd") + ".txt");
            var logLine = $"[{DateTime.Now}] [{level}] {message}";

            File.AppendAllText(logFilePath, logLine + Environment.NewLine);
        }

        public void LogDebug(string message)
        {
            LogMessage(LogLevel.Debug, message);
        }

        public void LogInfo(string message)
        {
            LogMessage(LogLevel.Info, message);
        }

        public void LogError(string message)
        {
            LogMessage(LogLevel.Error, message);
        }

        public void LogWarning(string message)
        {
            LogMessage(LogLevel.Warning, message);
        }
    }
}

