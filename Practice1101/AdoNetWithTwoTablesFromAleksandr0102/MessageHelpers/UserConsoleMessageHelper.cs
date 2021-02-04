using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.MessageHelpers
{
    public static class UserConsoleMessageHelper
    {
        public static void ShowUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.UserRole != null)
                {
                    Console.WriteLine($"{user.Id}. {user.Name}, {user.UserRole.Name}");
                }
                else
                {
                    Console.WriteLine($"{user.Id}. {user.Name}, no roles");
                }
                
            }
        }
    }
}
