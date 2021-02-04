using AdoNetWithTwoTablesFromAleksandr0102.DI;
using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Views
{
    public class UserView : IUserView
    {
        IUserService userService;
        IRoleService roleService;
        public UserView(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public void ShowAllUsers()
        {
            foreach (var user in this.userService.GetAllUsers())
            {
                Console.WriteLine($"{user.Id}. {user.Name}, {user.UserRole.Name}");
            }
        }

        public void CreateUser()
        {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Available position: ");
            List<Role> roles = this.roleService.GetAllRoles().ToList();

            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id} - {role.Name}");
            }

            Console.WriteLine("Enter position id:");
            int roleId = Convert.ToInt32(Console.ReadLine());

            User user = new User()
            {
                Name = name,
                UserRole = roles.Where(x => x.Id == roleId).FirstOrDefault()
            };

            this.userService.CreateUser(user);
            Branch.StartApp();
        }
    }
}
