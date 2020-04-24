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
        private bool IsLoggedIn { get; set; }
        private User User { get; set; }

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
                return true;
            }
            Console.WriteLine("Wrong credentials! Please try again!");
            return false;
        }

        public void CheckCar(Car car)
        {
            if (Subject != null && IsLoggedIn == true)
            {
                Subject.CheckCar(User.Car);
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
                Subject.ServiceCar(User.Car);
                User.Car.CarDetails.CarFaultsManager.AddFault("Probleme la frane");
                User.Car.CarDetails.CarFaultsManager.CompleteCurrentOperation();
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
    }
}
