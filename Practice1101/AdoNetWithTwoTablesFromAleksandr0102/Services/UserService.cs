using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateRole(User user)
        {
            userRepository.Create(user);
        }

        public List<User> GetAllRoles()
        {
            return userRepository.GetAll().ToList();
        }

        public void UpdateRole(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteRole(int id)
        {
            userRepository.Delete(id);
        }
    }
}
