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
            this.userRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user.Id);
        }

        public User GetUser(int id)
        {
            return this.userRepository.Get(id);
        }
    }
}
