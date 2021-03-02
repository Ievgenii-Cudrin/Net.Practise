using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    interface IUserView
    {
        void ShowAllUsers();

        void CreateUser();

        void UpdateUser();

        void DeleteUser();
    }
}
