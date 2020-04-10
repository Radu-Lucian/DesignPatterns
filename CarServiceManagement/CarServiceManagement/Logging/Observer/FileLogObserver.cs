using System;
using System.IO;

namespace CarServiceManagement.Logging.Observer
{
    public class FileLogObserver : ILogObserver
    {
        public bool IgnoreCallerInfo { get; set; }
        public FileInfo OutputFile { get; }

        public FileLogObserver(FileInfo outputFile) : this(outputFile, false)
        { }

        public FileLogObserver(FileInfo outputFile, bool ignoreCallerInfo)
        {
            IgnoreCallerInfo = ignoreCallerInfo;
            OutputFile = outputFile;
            if (File.Exists(OutputFile.FullName))
            {
                File.Delete(OutputFile.FullName);
            }
        }

        public void Log(Status status, string message, DateTime timeStamp, string callerName, string sourceFile, int sourceLineNumber)
        {
            if (IgnoreCallerInfo)
            {
                File.AppendAllText(OutputFile.FullName, $"[{status.ToString()}] [{timeStamp.ToString("hh:mm:ss.fff")}] {message} \n");
            }
            else
            {
                File.AppendAllText(OutputFile.FullName, $"[{status.ToString()}] [{timeStamp.ToString("hh:mm:ss.fff")}] {message} ({callerName}, {sourceFile}, {sourceLineNumber}) \n");
            }
        }
    }
}
