using CarServiceManagement.Chain_Of_Responsability;
using CarServiceManagement.Decorator;
using CarServiceManagement.State;
using CarServiceManagement.Util;
using System;

namespace CarServiceManagement.Proxy
{
    public class Menu : IMenu
    {
        private static UserRequest serviceManager = new ServiceManager();
        private static UserRequest serviceEmployee = new ServiceEmployee(serviceManager);
        private static UserRequest userRequest = new UserRequest(serviceEmployee);

        public void CheckCar(Car car)
        {
            car.UpdateState(EStateOption.CheckCar);
        }

        public void LogOut()
        {
            Console.WriteLine("Logged out successfully!");
        }

        public void RentACar()
        {
            Console.WriteLine("Your choices are: \n");
            IPackage basic = new BasicPackage();
            Console.WriteLine("1-"+basic.ToString());
            IPackage gold = new GoldDecorator(basic);
            Console.WriteLine("2-"+gold.ToString());
            IPackage platinum = new PlatinumDecorator(basic);
            Console.WriteLine("3-"+platinum.ToString());
            Console.WriteLine("4-Abort");

            Console.WriteLine("What do you wish for?");
            int input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    userRequest.ApplyCarRentalRequest(new RentCarRequest(basic));
                    break;
                case 2:
                    userRequest.ApplyCarRentalRequest(new RentCarRequest(gold));
                    break;
                case 3:
                    userRequest.ApplyCarRentalRequest(new RentCarRequest(platinum));
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        public void ServiceCar(Car car)
        {
            car.UpdateState(EStateOption.RepairCar);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
