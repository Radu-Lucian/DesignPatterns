﻿using CarServiceManagement.Logging;
using CarServiceManagement.Logging.Observer;
using CarServiceManagement.Proxy;
using CarServiceManagement.Model;
using CarServiceManagement.State;
using CarServiceManagement.Util;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CarServiceManagement
{
    class Program
    {
        static void DisplayMenu()
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
        }

        static void Main(string[] args)
        {
            string outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo outputLoggingFile = new FileInfo(Path.Combine(outputPath, "output.txt"));
            Logger.Instance.AddObservers(
                new FileLogObserver(outputLoggingFile),
                new ErrorScreenCaptureObserver(outputPath)
            );

            var menu = new ProxyMenu();
            int input;

            DisplayMenu();

            while (true)
            {
                var line = Console.ReadLine();

                if (!int.TryParse(line, out int result))
                {
                    line = Console.ReadLine();
                }

                if (int.TryParse(line, out int result2))
                {
                    input = Convert.ToInt32(line);

                    switch (input)
                    {
                        case 1:
                            Console.Write("Please enter username: ");
                            string username = Console.ReadLine();
                            Console.Write("Please enter password: ");
                            string password = Console.ReadLine();
                            menu.LogIn(username, password);
                            break;
                        case 2:
                            menu.CheckCar(null);
                            break;
                        case 3:
                            menu.ServiceCar(null);
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

                    DisplayMenu();
                }

            }
        }
    }
}
