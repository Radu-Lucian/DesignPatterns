using CarServiceManagement.Logging.Observer;
using System;
using System.Collections.Generic;

namespace CarServiceManagement.Logging
{
    public class Logger
    {
        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        private Logger() { }

        private readonly IList<ILogObserver> observers = new List<ILogObserver>();
        private readonly object lockObject = new object();

        public void Log(
            Status status,
            string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            lock (lockObject)
            {
                foreach (var obs in observers)
                {
                    obs.Log(status, message, DateTime.Now, memberName, sourceFilePath, sourceLineNumber);
                }
            }
        }

        public void LogOk(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(Status.Ok, message, memberName, sourceFilePath, sourceLineNumber);
        }

        public void LogError(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(Status.Error, message, memberName, sourceFilePath, sourceLineNumber);
        }

        public void LogWarning(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(Status.Warning, message, memberName, sourceFilePath, sourceLineNumber);
        }

        public void LogInfo(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(Status.Info, message, memberName, sourceFilePath, sourceLineNumber);
        }

        public void AddObservers(IList<ILogObserver> observerList)
        {
            foreach (var obs in observerList)
            {
                observers.Add(obs);
            }
        }

        public void AddObservers(params ILogObserver[] observerList)
        {
            foreach (var obs in observerList)
            {
                observers.Add(obs);
            }
        }

        public void AddObserver(ILogObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(ILogObserver observer)
        {
            observers.Remove(observer);
        }

        public void RemoveAllObservers()
        {
            observers.Clear();
        }
    }
}
