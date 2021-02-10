using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);

        List<User> GetAllUsers();

        void UpdateUser(User user);

        void DeleteUser(User user);

        User GetUser(int id);
    }
}
