using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.ProgramBranch;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.MessageHelpers
{
    public static class RoleCondoleMessageHelpers
    {
        public static void ShowRoles(List<Role> roles)
        {
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id} - {role.Name}");
            }
        }
    }
}
