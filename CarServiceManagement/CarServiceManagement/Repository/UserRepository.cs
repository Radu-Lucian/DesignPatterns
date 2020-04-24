﻿using CarServiceManagement.Model;
using CarServiceManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Repository
{
    public class UserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User(1, "luci", "luci", EUserType.CLIENT),
            new User(2, "iulia", "iulia", EUserType.CLIENT),
            new User(3, "ioana", "ioana", EUserType.CLIENT),
            new User(4, "george", "george", EUserType.CLIENT)
        };

        public UserRepository()
        {
            SetCarToUser("luci", "2FMHK6DT7FBA653587");
            SetCarToUser("iulia", "2FMHK6DT7FBA101010");
            SetCarToUser("ioana", "2FMHK6DT7FBA13402");
            SetCarToUser("george", "2FMHK6DT7FBA251530");
        }

        public bool CheckIfUserExists(string username, string password)
        {
            IEnumerable<User> userList = GetUsers();
            foreach (var user in userList)
            {
                if (username == user.Username && password == user.Password)
                    return true;
            }
            return false;
        }

        public User FindUserByUsername(string username)
        {
            IEnumerable<User> userList = GetUsers();
            foreach (var user in userList)
            {
                if (username == user.Username)
                    return user;
            }
            return null;
        }

        public static IEnumerable<User> GetUsers()
        {
            foreach (var user in Users)
            {
                yield return user;
            }
        }

        public void SetCarToUser(string username, string VIN)
        {
            var car = CarRepository.Instance.GetCar(VIN);
            if (car != null)
            {
                var user = FindUserByUsername(username);
                if (user != null)
                {
                    user.SetCar(car);
                }
            }
        }
    }
}
