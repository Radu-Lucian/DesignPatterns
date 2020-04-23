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
        private User User { get; set; } = new User(1, "test", "test", EType.CLIENT);
        private IMenu Subject { get; set; }
        private bool IsLoggedIn { get; set; }

        public bool LogIn(User user)
        {
            if (this.User.Password == user.Password && this.User.Username == user.Username)
            {
                if (Subject == null)
                {
                    Subject = new Menu();
                }
                IsLoggedIn = true;
                Console.WriteLine($"You are now logged in as {user.Username}!");
                return true;
            }
            Console.WriteLine("Wrong credentials! Please try again!");
            return false;
        }

        public void CheckCar(Car car)
        {
            if (Subject != null && IsLoggedIn == true)
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
                IsLoggedIn = false;
                Subject.LogOut();
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void RentACar()
        {
            if (Subject != null && IsLoggedIn == true)
            {
                Subject.RentACar();
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void ServiceCar(Car car)
        {
            if (Subject != null && IsLoggedIn == true)
            {
                Subject.ServiceCar(car);
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void Exit()
        {
            Subject.Exit();
        }
    }
}
