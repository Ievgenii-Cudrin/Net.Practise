using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(User user);

        public List<User> GetAllUsers();

        public void UpdateUser(User user);

        public void DeleteUser(int id);
    }
}
