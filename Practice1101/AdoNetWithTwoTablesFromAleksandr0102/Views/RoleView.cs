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
            RoleCondoleMessageHelpers.ShowRoles(roleService.GetAllRoles());
            Console.WriteLine("Enter role id to delete: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            //delete role
            userService.DeleteUser(idToDelete);
            Branch.StartApp();
        }

        public void ShowAllRoles()
        {
            RoleCondoleMessageHelpers.ShowRoles(roleService.GetAllRoles().ToList());
            Branch.StartApp();
        }

        public void UpdateRole()
        {
            RoleCondoleMessageHelpers.ShowRoles(this.roleService.GetAllRoles());
            Console.WriteLine("Enter role id for update:");
            int roleId = Convert.ToInt32(Console.ReadLine());
            Role role = roleService.GetRole(roleId);
            //Todo
            Console.WriteLine("Enter role name: ");
            string name = Console.ReadLine();
            role.Name = name;
            roleService.UpdateRole(role);
            Branch.StartApp();
        }

        public void ShowUsersInOneRole()
        {
            Console.WriteLine("Enter role id for show user in this role:");
            int roleId = Convert.ToInt32(Console.ReadLine());
            UserConsoleMessageHelper.ShowUsers(roleService.GetUsersInRole(roleId));
            Branch.StartApp();
        }
    }
}
