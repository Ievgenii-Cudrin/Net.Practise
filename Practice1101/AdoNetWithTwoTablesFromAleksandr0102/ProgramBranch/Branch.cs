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
            $"\n5. Create role" +
            $"\n6. Show all roles" +
            $"\n7. Update role" +
            $"\n8. Delete role" +
            $"\n9 Show all users in one role"
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
                    roleView.CreateRole();
                    break;
                case ("6"):
                    roleView.ShowAllRoles();
                    break;
                case ("7"):
                    roleView.UpdateRole();
                    break;
                case ("8"):
                    roleView.DeleteRole();
                    break;
                case ("9"):
                    roleView.ShowUsersInOneRole();
                    break;
                default:
                    StartApp();
                    break;
            }
        }
    }
}
