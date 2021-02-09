using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PricticeDapper0802.Services
{
    public class UserService : IUserService
    {
        IRepository<User> userRepository;
        public UserService(IRepository<User> userRepo)
        {
            this.userRepository = userRepo;
        }

        public void AddUser(User user)
        {
            this.userRepository.Add(user).Wait(); ;
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user).Wait();
        }

        public void DeleteUser(int id)
        {
            User user = this.userRepository.FindByID(id).Result;

            if(user != null)
            {
                this.userRepository.Delete(user).Wait();
            }
        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.FindAll().Result.ToList();
        }
    }
}
