using CarServiceManagement.Logging;
using CarServiceManagement.Logging.Observer;
using CarServiceManagement.Menu;
using CarServiceManagement.Model;
using System;
using System.IO;
using System.Reflection;

namespace CarServiceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo outputLoggingFile = new FileInfo(Path.Combine(outputPath, "output.txt"));
            Logger.Instance.AddObservers(
                new FileLogObserver(outputLoggingFile),
                new ConsoleLogger() { IgnoreCallerInfo = true },
                new ErrorScreenCaptureObserver(outputPath)
            );

            Logger.Instance.LogOk("Test");
            Logger.Instance.LogOk("Test1");
            Logger.Instance.LogOk("Test2");
            Logger.Instance.LogOk("Test3");
            Logger.Instance.LogError("Test3");
            Logger.Instance.LogWarning("Test3");

            var menu = new ProxyMenu();
            var user = new User(1, "test", "test", EType.CLIENT);
            menu.LogOut();
            menu.LogIn(user);
            menu.LogOut();

            Console.ReadKey();
        }
    }
}
