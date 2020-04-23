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
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            Console.WriteLine("Logged out successfully!");
        }

        public void RentACar()
        {
            Console.WriteLine("Rent a car!");
        }

        public void ServiceCar(Car car, CarFaults carFaults)
        {
            throw new NotImplementedException();
        }
    }
}
