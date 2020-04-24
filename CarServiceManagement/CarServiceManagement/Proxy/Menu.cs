using CarServiceManagement.Chain_Of_Responsability;
using CarServiceManagement.Decorator;
using CarServiceManagement.Repository;
using CarServiceManagement.State;
using CarServiceManagement.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            Console.WriteLine("1-" + basic.ToString());
            IPackage gold = new GoldDecorator(basic);
            Console.WriteLine("2-" + gold.ToString());
            IPackage platinum = new PlatinumDecorator(basic);
            Console.WriteLine("3-" + platinum.ToString());
            Console.WriteLine("4-Abort");

            Console.WriteLine("What do you wish for?");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
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

        public void PrintCarsInService()
        {
            List<Car> carsInService = CarRepository.Instance.GetCarsInService();
            foreach (Car car in carsInService)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void UpdateCarState()
        {
            Console.WriteLine("Enter VIN for the car's you want to update");
            string vin = Console.ReadLine();
            Car carToUpdate = CarRepository.Instance.GetCar(vin);
            if (carToUpdate != null)
            {
                switch (carToUpdate.CarState.GetType().Name)
                {
                    case "NotStartedState":
                        Console.WriteLine("Currently not revised by anyone.");
                        Console.WriteLine("Please choose one of the below:");
                        bool ok = true;
                        while (ok)
                        {
                            Console.WriteLine("1-Add fault");
                            Console.WriteLine("2-Abort");
                            int input = Convert.ToInt32(Console.ReadLine());
                            switch (input)
                            {
                                case 1:
                                    Console.WriteLine("Fault: ");
                                    string fault=Console.ReadLine();
                                    carToUpdate.SetCarState(carToUpdate.WorkingOnState);
                                    carToUpdate.CarDetails.CarFaultsManager.AddFault(fault);
                                    break;
                                case 2:
                                    ok = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }
                        }
                        break;
                    case "WorkingState":
                        Console.WriteLine("Curently in process of fixing.");
                        carToUpdate.CarDetails.CheckCarState();
                        Console.WriteLine("Please choose one of the below:");
                        Console.WriteLine("1-Complete current operation");
                        Console.WriteLine("2-Complete all operations - the car is totally fixed");
                        Console.WriteLine("3-Abort");
                        int input2 = Convert.ToInt32(Console.ReadLine());
                        switch (input2)
                        {
                            case 1:
                                carToUpdate.CarDetails.CarFaultsManager.CompleteCurrentOperation();
                                if (carToUpdate.CarDetails.CarFaultsManager.IsDone())
                                    carToUpdate.SetCarState(carToUpdate.FixedState);
                                Console.WriteLine("Operation completed successfully!");
                                break;
                            case 2:
                                carToUpdate.CarDetails.CarFaultsManager.CompleteAllOperations();
                                carToUpdate.SetCarState(carToUpdate.FixedState);
                                Console.WriteLine("Operation completed successfully! The car is ready to leave the service.");
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                        break;
                }
                CarRepository.Instance.UpdateCar(carToUpdate);
            }
            else
            {
                Console.WriteLine("INVALID VIN");
            }
        }
    }
}
