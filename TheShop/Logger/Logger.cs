using System;

namespace TheShop
{
    public class Logger : ILogger
    {
        ILogger _logger;

        public Logger(ILogger logger)
        {
            this._logger = logger;
        }
        public void LogMessage(string message)
        {
            this._logger.LogMessage(message);
        }
    }

    public class InfoLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Info: " + message);
        }
    }

    public class ErrorLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Error: " + message);
        }
    }

    public class DebugLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}

