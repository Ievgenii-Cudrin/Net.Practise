using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class LogInService : ILogInService
    {
        IRepository<User> userRepository;
        IWorkWithAuthorizedUser authorizedUser;
        IStatusService statusService;

        public LogInService(
            IRepository<User> userRepository,
            IWorkWithAuthorizedUser authorizedUser,
            IStatusService statusService)
        {
            this.userRepository = userRepository;
            this.authorizedUser = authorizedUser;
            this.statusService = statusService;
        }

        public bool LogIn(string name, string password)
        {
            User user = this.userRepository.Get(x => x.Name == name && x.Password == password).FirstOrDefault();

            if(user != null)
            {
                this.authorizedUser.SetUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogOut()
        {
            this.authorizedUser.CleanUser();
        }
    }
}
