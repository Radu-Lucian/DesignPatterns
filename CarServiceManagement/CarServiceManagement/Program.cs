using CarServiceManagement.Logging;
using CarServiceManagement.Logging.Observer;
using CarServiceManagement.Proxy;
using CarServiceManagement.Model;
using CarServiceManagement.State;
using CarServiceManagement.Util;
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
                new ErrorScreenCaptureObserver(outputPath)
            );

            var menu = new ProxyMenu();
            var user = new User(1, "test", "test", EType.CLIENT);
            var car = new Car(new CarDetails(ECarType.EDiesel, "Ford", "grey", "2FMHK6DT7FBA13402", "BV 29 STO"));

            int input;
            while (true)
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
                        Console.WriteLine("Please enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Please enter password: ");
                        string password = Console.ReadLine();
                        menu.LogIn(username, password);
                        break;
                    case 2:
                        menu.CheckCar(car);
                        break;
                    case 3:
                        menu.ServiceCar(car);
                        car.CarDetails.CarFaultsManager.AddFault("Probleme la frane");
                        car.CarDetails.CarFaultsManager.CompleteCurrentOperation();
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
