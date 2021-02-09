using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PricticeDapper0802.Services
{
    public class UserService
    {
        IRepository<User> userRepository;
        public UserService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        public void AddUser(User user)
        {
            this.userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            this.userRepository.Delete(user);
        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.FindAll().Result.ToList();
        }
    }
}
