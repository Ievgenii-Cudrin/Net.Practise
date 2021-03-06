﻿using AdoNetWithTwoTablesFromAleksandr0102.DI;
using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.MessageHelpers;
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

        public void CreateUser()
        {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Available position: ");
            RoleCondoleMessageHelpers.ShowRoles(this.roleService.GetAllRoles().ToList());
            Console.WriteLine("Enter position id:");
            int roleId = Convert.ToInt32(Console.ReadLine());

            User user = new User()
            {
                Name = name,
                UserRole = roleService.GetAllRoles().Where(x => x.Id == roleId).FirstOrDefault()
            };

            this.userService.CreateUser(user);
            Branch.StartApp();
        }

        public void UpdateUser()
        {
            UserConsoleMessageHelper.ShowUsers(this.userService.GetAllUsers().ToList());
            Console.WriteLine("Enter user id for update:");
            int userId = Convert.ToInt32(Console.ReadLine());
            User userToUpdate = userService.GetUser(userId);
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Available position: ");
            RoleCondoleMessageHelpers.ShowRoles(this.roleService.GetAllRoles().ToList());
            //get id 
            Console.WriteLine("Enter role id for update:");
            int roleId = Convert.ToInt32(Console.ReadLine());
            //set values
            userToUpdate.Name = name;
            userToUpdate.UserRole = roleService.GetAllRoles().Where(x => x.Id == roleId).FirstOrDefault();
            //update user
            this.userService.UpdateUser(userToUpdate);
            Branch.StartApp();
        }

        public void DeleteUser()
        {
            UserConsoleMessageHelper.ShowUsers(this.userService.GetAllUsers().ToList());
            Console.WriteLine("Enter id user id to delete: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            //delete user
            this.userService.DeleteUser(this.userService.GetUser(idToDelete));
            Branch.StartApp();
        }

        public void ShowAllUsers()
        {
            UserConsoleMessageHelper.ShowUsers(userService.GetAllUsers());
            Branch.StartApp();
        }
    }
}
