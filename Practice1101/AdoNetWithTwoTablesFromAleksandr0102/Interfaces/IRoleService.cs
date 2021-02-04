using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleService
    {
        public void CreateRole(Role role);

        public void ShowAllRole();

        public List<Role> GetAllRoles();

        public void UpdateRole(Role role);

        public void DeleteRole(int id);

        public List<User> GetUsersInRole(int roleId);

        public Role GetRole(int id);
    }
}
