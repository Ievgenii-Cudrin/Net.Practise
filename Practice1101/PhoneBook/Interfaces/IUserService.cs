using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IUserService
    {
        IOperationResult CreateUser(User user);

        User GetUser(Guid id);

        bool ExistUser(string name);

        User GetUserByName(string name);
    }
}
