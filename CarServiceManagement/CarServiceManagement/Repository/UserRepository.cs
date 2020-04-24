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
        private readonly List<User> Users = new List<User>
        {
            new User(1, "luci", "luci", EType.ADMIN),
            new User(2, "iulia", "iulia", EType.CLIENT),
            new User(3, "ioana", "ioana", EType.ADMIN),
            new User(4, "george", "george", EType.CLIENT)
        };

        public bool CheckIfUserExists(string username, string password)
        {
            foreach (var user in Users)
            {
                if (username == user.Username && password == user.Password)
                    return true;
            }
            return false;
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public void PrintUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}