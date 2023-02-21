namespace Daniella_BlazorUI.Services.LoggerService
{
    public interface ILogToFileService
    {
        void LogDebug(string message);

        void LogInfo(string message);

        void LogError(string message);

        void LogWarning(string message);
    }
}
