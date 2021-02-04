using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class UserService
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

        public void ShowAllRole()
        {
            foreach (var user in userRepository.GetAll().ToList())
            {
                Console.WriteLine($"{user.Id}. {user.Name}");
            }
        }

        public List<Role> GetAllRoles()
        {
            return userRepository.GetAll().ToList();
        }

        public void UpdateRole(Role role)
        {
            userRepository.Update(role);
        }

        public void DeleteRole(int id)
        {
            userRepository.Delete(id);
        }
    }
}
