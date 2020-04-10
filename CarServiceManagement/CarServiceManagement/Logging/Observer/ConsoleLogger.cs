using System;

namespace CarServiceManagement.Logging.Observer
{
    public class ConsoleLogger : ILogObserver
    {
        public bool IgnoreCallerInfo { get; set; }

        public ConsoleLogger()
        {
            IgnoreCallerInfo = false;
        }

        public ConsoleLogger(bool ignoreCallerInfo)
        {
            IgnoreCallerInfo = ignoreCallerInfo;
        }

        public void Log(Status status, string message, DateTime timeStamp, string callerName, string sourceFile, int sourceLineNumber)
        {
            if (IgnoreCallerInfo)
            {
                Console.WriteLine($"[{status.ToString()}] [{timeStamp.ToString("hh:mm:ss.fff")}] {message}");
            }
            else
            {
                Console.WriteLine($"[{status.ToString()}] [{timeStamp.ToString("hh:mm:ss.fff")}] {message} ({callerName}, {sourceFile}, {sourceLineNumber})");
            }
        }
    }
}
