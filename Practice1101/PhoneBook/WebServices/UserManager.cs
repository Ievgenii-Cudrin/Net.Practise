using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.WebServices
{
    public class UserManager
    {
        private readonly IUserService userService;

        public UserManager(IUserService userService)
        {
            this.userService = userService;
        }

        public bool CreateUSer(User user)
        {
            bool uniqueUser = user == null ? false : !this.userService.ExistUser(user.Name);

            if(!uniqueUser)
            {
                return false;
            }

            this.userService.CreateUser(user);
            return true;
        }

        public User GetByLogin(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return this.userService.GetUserByName(name);
        }

        public bool VerifyUserExists(User user)
        {
            if (user == null)
            {
                return false;
            }

            return this.userService.ExistUser(user.Name);
        }
    }
}
