using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleView
    {
        void ShowAllRoles();

        void CreateRole();

        void UpdateRole();

        void DeleteRole();
    }
}
