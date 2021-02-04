using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleView
    {
        public void ShowAllRoles();

        public void CreateRole();

        public void UpdateRole();

        public void DeleteRole();

        public void ShowUsersInOneRole();
    }
}
