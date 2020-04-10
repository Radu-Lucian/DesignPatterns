using System;

namespace CarServiceManagement.Logging.Observer
{
    public interface ILogObserver
    {
        void Log(Status status, string message, DateTime timeStamp, string callerName, string sourceFile, int sourceLineNumber);
    }
}
