using PricticeDapper0802.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        User GetUserByEmail(string email);
    }
}
