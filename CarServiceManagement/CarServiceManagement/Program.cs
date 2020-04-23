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

            var car = new Car(ECarType.EDiesel, "Ford", "grey", "2FMHK6DT7FBA13402", "BV 29 STO");

            menu.LogOut();
            menu.LogIn(user);
            menu.LogOut();
            menu.RentACar();
            menu.LogIn(user);
            menu.RentACar();

            //Console.ReadKey();
            Console.WriteLine("\n");

            int input;
            while(true)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Log In");
                Console.WriteLine("2 - Check car");
                Console.WriteLine("3 - Service car");
                Console.WriteLine("4 - Rent a car");
                Console.WriteLine("5 - Log Out");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("------------------");
                Console.WriteLine("\n");

                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        menu.LogIn(user);
                        break;
                    case 2:
                        menu.CheckCar(car);
                        break;
                    case 3:
                        menu.ServiceCar(car);
                        car.CarFaultsManager.AddFault("Probleme la frane");
                        car.CarFaultsManager.CompleteCurrentOperation();
                        break;
                    case 4:
                        menu.RentACar();
                        break;
                    case 5:
                        menu.LogOut();
                        break;
                    case 6:
                        menu.Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;

                }

            }
        }
    }
}
