using CarServiceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Menu
{
    public class Menu : IMenu
    {
        public void CheckCar(Car car)
        {
            car.CheckCarState();
        }

        public void LogOut()
        {
            Console.WriteLine("Logged out successfully!");
        }

        public void RentACar()
        {
            Console.WriteLine("Rent a car!");
            //aici trebuie sa ne legam de pachete(decorator)
        }

        public void ServiceCar(Car car)
        {
            car.CarGoesToService();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
