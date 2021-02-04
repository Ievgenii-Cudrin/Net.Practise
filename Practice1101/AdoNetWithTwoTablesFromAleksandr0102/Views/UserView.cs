using AdoNetWithTwoTablesFromAleksandr0102.DI;
using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Views
{
    public class UserView
    {
        IUserService userService = Startup.ConfigureService().GetRequiredService<IUserService>();
        IRoleService roleService = Startup.ConfigureService().GetRequiredService<IRoleService>();
        public UserView(IUserService userService)
        {
            this.userService = userService;
        }

        public void ShowAllUsers()
        {
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine($"{user.Id}. {user.Name}, {user.UserRole.Name}");
            }
        }

        public void CreateUser()
        {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Available position: ");
            List<Role> roles = roleService.GetAllRoles().ToList();

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

            userService.CreateUser(user);
        }
    }
}
