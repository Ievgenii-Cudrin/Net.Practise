using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    interface IUserView
    {
        public void ShowAllUsers();

        public void CreateUser();

        public void UpdateUser();
    }
}
