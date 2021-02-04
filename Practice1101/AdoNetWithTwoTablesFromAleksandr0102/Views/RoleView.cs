using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.MessageHelpers;
using AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Enter role name: ");
            string name = Console.ReadLine();

            Role role = new Role()
            {
                Name = name,
            };

            this.roleService.CreateRole(role);
            Branch.StartApp();
        }

        public void DeleteRole()
        {
            throw new NotImplementedException();
        }

        public void ShowAllRoles()
        {
            RoleCondoleMessageHelpers.ShowRoles(roleService.GetAllRoles().ToList());
            Branch.StartApp();
        }

        public void UpdateRole()
        {
            throw new NotImplementedException();
        }
    }
}
