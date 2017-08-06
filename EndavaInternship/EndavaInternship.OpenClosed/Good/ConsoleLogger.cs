using System;

namespace EndavaInternship.OpenClosed.Good
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}