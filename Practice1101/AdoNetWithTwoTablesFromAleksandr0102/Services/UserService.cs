using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            userRepository.Create(user);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll().ToList();
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.Delete(id);
        }
    }
}
