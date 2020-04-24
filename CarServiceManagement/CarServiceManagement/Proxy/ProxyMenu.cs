using CarServiceManagement.Logging;
using CarServiceManagement.Model;
using CarServiceManagement.Repository;
using CarServiceManagement.State;
using CarServiceManagement.Util;
using System;
using System.Collections.Generic;

namespace CarServiceManagement.Proxy
{
    public class ProxyMenu : IMenu
    {
        private IMenu Subject { get; set; }
        private bool IsLoggedIn { get; set; } = false;
        private User User { get; set; }

        public bool GetIsLoggedIn()
        {
            return IsLoggedIn;
        }

        public bool LogIn(string username, string password)
        {
            if (UserRepository.Instance.CheckIfUserExists(username, password) == true)
            {
                if (Subject == null)
                {
                    Subject = new Menu();
                }
                IsLoggedIn = true;
                User = UserRepository.Instance.FindUserByUsername(username);
                Logger.Instance.LogOk($"User has logged in with username: {username}");
                Console.WriteLine($"You are now logged in as {username}!");
                if(User.Type==EUserType.CLIENT)
                    Console.WriteLine(User.Car.ToString());
                return true;
            }
            Console.WriteLine("Wrong credentials! Please try again!");
            return false;
        }

        public void CheckCar(Car car)
        {
            if (Subject != null)
            {
                if (IsLoggedIn == true && User.Type == EUserType.CLIENT)
                {
                    Subject.CheckCar(User.Car);
                }
                else if (User.Type == EUserType.ADMIN)
                {
                    Console.WriteLine("Invalid operation. CLIENT only");
                }
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
                if (IsLoggedIn == true)
                {
                    IsLoggedIn = false;
                    Subject.LogOut();
                }
                else
                {
                    Console.WriteLine("You need to log in first!");
                }
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
                if (IsLoggedIn == true && User.Type == EUserType.CLIENT)
                {
                    Subject.RentACar();
                }
                else if (User.Type == EUserType.ADMIN)
                {
                    Console.WriteLine("Invalid operation. CLIENT only");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void ServiceCar(Car car)
        {
            if (Subject != null)
            {
                if (IsLoggedIn == true && User.Type == EUserType.CLIENT)
                {
                    Subject.ServiceCar(User.Car);
                }
                else if (User.Type == EUserType.ADMIN)
                {
                    Console.WriteLine("Invalid operation. CLIENT only");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }

        public void Exit()
        {
            if (Subject != null)
            {
                Subject.Exit();
            }
            else
            {
                Subject = new Menu();
                Subject.Exit();
            }
        }

        public void PrintCarsInService()
        {
            if (Subject != null)
            {
                if (IsLoggedIn == true && User.Type == EUserType.ADMIN)
                {
                    Subject.PrintCarsInService();
                }
                else if (User.Type == EUserType.ADMIN)
                {
                    Console.WriteLine("Invalid operation. ADMIN only");
                }
            }
            else
            {
                Console.WriteLine("You need to log in first!");
            }
        }
    }
}
