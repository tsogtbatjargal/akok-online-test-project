namespace AKOK_BlazorServer.Services
{
    public class Logger : ILogger
    {
        public void LogInformation(string message)
        {
            // Implement logging of informational messages here, e.g. to a database, file, or console.
            Console.WriteLine($"INFO: {message}");
        }

        public void LogError(Exception exception, string message)
        {
            // Implement logging of error messages and exceptions here, e.g. to a database, file, or console.
            Console.WriteLine($"ERROR: {message}. Exception details: {exception}");
        }
    }
}
