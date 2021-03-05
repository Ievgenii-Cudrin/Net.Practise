using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IWorkWithAuthorizedUser : IAuthorizedUser
    {
        public void SetUser(User user);

        public void CleanUser();
    }
}
