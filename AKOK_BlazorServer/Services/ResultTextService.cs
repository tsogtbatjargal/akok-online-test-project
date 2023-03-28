namespace AKOK_BlazorServer.Services
{
    public class ResultTextService
    {
        private readonly IConfiguration _config;

        public ResultTextService(IConfiguration config)
        {
            _config = config;
        }

        public string GetLongText(int number)
        {
            return _config[$"LongText:{number}"];
        }
    }
}
