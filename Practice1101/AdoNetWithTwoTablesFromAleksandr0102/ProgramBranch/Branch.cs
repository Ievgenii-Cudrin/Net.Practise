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

        public static void StartApp()
        {
            Console.WriteLine($"Please, make your choice: " +
            $"\n1.Create user" +
            $"\n2 Pass the available course" +
            $"\n3 Сontinue the started course" +
            $"\n4.See the list of all passed courses" +
            $"\n5.See the list of your skills" +
            $"\n6.See the list of courses in progress" +
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
                    break;
                case ("3"):
                    break;
                default:
                    StartApp();
                    break;
            }
        }
    }
}
