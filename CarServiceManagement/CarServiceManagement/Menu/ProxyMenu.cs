using CarServiceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Menu
{
    public class ProxyMenu : IMenu
    {
        public User User { get; set; } = new User(1, "test", "test", EType.CLIENT);
        public IMenu Subject { get; set; }

        public bool LogIn(User user)
        {
            if (this.User.Password == user.Password && this.User.Username == user.Username)
            {
                if (Subject == null)
                {
                    Subject = new Menu();
                }
                Console.WriteLine($"You are now logged in as {user.Username}!");
                return true;
            }
            Console.WriteLine("Wrong credentials! Please try again!");
            return false;
        }

        public void CheckCar(Car car)
        {
            if (Subject != null)
            {
                Subject.CheckCar(car);
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void LogOut()
        {
            if (Subject != null)
            {
                Subject.LogOut();
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void RentACar()
        {
            if (Subject != null)
            {
                Subject.RentACar();
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void ServiceCar(Car car, CarFaults carFaults)
        {
            if (Subject != null)
            {
                Subject.ServiceCar(car, carFaults);
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }
    }
}
