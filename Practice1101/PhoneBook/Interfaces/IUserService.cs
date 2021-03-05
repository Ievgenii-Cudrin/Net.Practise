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

        IOperationResult UpdateUser(User user);

        IOperationResult Delete(Guid id);

        User GetUser(Guid id);
    }
}
