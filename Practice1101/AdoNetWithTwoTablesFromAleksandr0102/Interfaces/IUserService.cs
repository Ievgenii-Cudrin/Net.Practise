using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IUserService
    {
        public void CreateRole(User user);

        public void ShowAllRole();

        public List<User> GetAllRoles();

        public void UpdateRole(User user);

        public void DeleteRole(int id);
    }
}
