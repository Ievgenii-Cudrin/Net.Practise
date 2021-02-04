using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleView
    {
        public void ShowAllUsers();

        public void CreateUser();

        public void UpdateUser();

        public void DeleteUser();
    }
}
