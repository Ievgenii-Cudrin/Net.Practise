using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(Role role);

        Role GetRole(int id);
    }
}
