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
        private bool IsLoggedIn { get; set; }
        private readonly UserRepository UsersList = new UserRepository();

        public bool LogIn(string username, string password)
        {
            if (UsersList.CheckIfUserExists(username, password) == true)
            {
                if (Subject == null)
                {
                    Subject = new Menu();
                }
                IsLoggedIn = true;
                Console.WriteLine($"You are now logged in as {username}!");
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
