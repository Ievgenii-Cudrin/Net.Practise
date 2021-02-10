using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        List<User> users;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.users = this.userRepository.GetAll().ToList();
        }

        public void CreateUser(User user)
        {
            this.userRepository.Create(user);
            this.users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user);
            this.users.Where(x => x.Id == user.Id).Select(x => x = user);
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user.Id);
            this.users.Remove(user);
        }

        public User GetUser(int id)
        {
            return this.users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
