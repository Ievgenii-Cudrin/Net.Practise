using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Views
{
    public class UserView
    {
        public void ShowAllRole()
        {
            foreach (var user in userRepository.GetAll().ToList())
            {
                Console.WriteLine($"{user.Id}. {user.Name}");
            }
        }
    }
}
