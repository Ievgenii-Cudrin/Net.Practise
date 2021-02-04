using AdoNetWithTwoTablesFromAleksandr0102.Entities;
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
                Console.WriteLine($"{user.Id}. {user.Name}, {user.UserRole.Name}");
            }
        }
    }
}
