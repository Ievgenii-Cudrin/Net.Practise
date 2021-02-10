using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(Role role);

        void ShowAllRole();

        List<Role> GetAllRoles();

        void UpdateRole(Role role);

        void DeleteRole(int id);

        Role GetRole(int id);
    }
}
