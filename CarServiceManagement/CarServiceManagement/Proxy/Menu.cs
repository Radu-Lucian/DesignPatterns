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
            IPackage basic = new BasicPackage();
            Console.WriteLine(basic.PackTime());
            IPackage gold = new GoldDecorator(basic);
            Console.WriteLine(gold.PackTime());
            IPackage platinum = new PlatinumDecorator(gold);
            Console.WriteLine(platinum.PackTime());

            userRequest.ApplyCarRentalRequest(new RentCarRequest(platinum));
            // cam asa functioneaza partea cu pachete, este totul rezolvat, mai trebuie un meniu sa isi aleaga utilizatorul tot ce doreste
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
