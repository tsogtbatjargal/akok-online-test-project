namespace AKOK_BlazorServer.Services
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogError(Exception exception, string message);
    }
}
