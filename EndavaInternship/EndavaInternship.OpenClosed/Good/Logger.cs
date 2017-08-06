namespace EndavaInternship.OpenClosed.Good
{
    public class Logger
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteLog(string message)
        {
            _logger.WriteLog(message);
        }
    }
}