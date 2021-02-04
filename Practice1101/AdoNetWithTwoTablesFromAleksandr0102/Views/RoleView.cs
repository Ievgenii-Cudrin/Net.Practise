using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Views
{
    public class RoleView : IRoleView
    {
        IUserService userService;
        IRoleService roleService;
        public RoleView(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public void CreateRole()
        {
            throw new NotImplementedException();
        }

        public void DeleteRole()
        {
            throw new NotImplementedException();
        }

        public void ShowAllRoles()
        {
            throw new NotImplementedException();
        }

        public void UpdateRole()
        {
            throw new NotImplementedException();
        }
    }
}
