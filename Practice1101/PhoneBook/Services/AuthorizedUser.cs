using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class AuthorizedUser : IWorkWithAuthorizedUser
    {
        private static User authorizedUser;

        public User User
        {
            get
            {
                return authorizedUser;
            }
        }

        public void CleanUser()
        {
            authorizedUser = null;
        }

        public void SetUser(User user)
        {
            authorizedUser = user;
        }
    }
}
