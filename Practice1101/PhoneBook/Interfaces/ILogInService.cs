using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface ILogInService
    {
        bool LogIn(string name, string password);

        public void LogOut();
    }
}
