using AdoNetWithTwoTablesFromAleksandr0102.DI;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch
{
    public static class Branch
    {
        static IUserView userView = Startup.ConfigureService().GetRequiredService<IUserView>();
        static IRoleView roleView = Startup.ConfigureService().GetRequiredService<IRoleView>();

        public static void StartApp()
        {
            Console.WriteLine($"Please, make your choice: " +
            $"\n1.Create user" +
            $"\n2 Show all users" +
            $"\n3 Update user" +
            $"\n4.Delete user" +
            $"\n5.See the list of your skills" +
            $"\n6. Show all roles" +
            $"\n7.My information" +
            $"\n8.LogOut"
            );

            string choice = Console.ReadLine();

            switch (choice)
            {
                case ("1"):
                    userView.CreateUser();
                    break;
                case ("2"):
                    userView.ShowAllUsers();
                    break;
                case ("3"):
                    userView.UpdateUser();
                    break;
                case ("4"):
                    userView.DeleteUser();
                    break;
                case ("5"):
                    userView.CreateUser();
                    break;
                case ("6"):
                    roleView.ShowAllRoles();
                    break;
                case ("7"):
                    userView.UpdateUser();
                    break;
                case ("8"):
                    userView.DeleteUser();
                    break;
                default:
                    StartApp();
                    break;
            }
        }
    }
}
