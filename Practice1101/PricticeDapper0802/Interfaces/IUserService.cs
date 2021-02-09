using PricticeDapper0802.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Interfaces
{
    public interface IUserService
    {
        public void AddUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(int id);

        public List<User> GetAllUsers();
    }
}
