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

        void DeleteUser(int id);

        User GetUser(int id);
    }
}
