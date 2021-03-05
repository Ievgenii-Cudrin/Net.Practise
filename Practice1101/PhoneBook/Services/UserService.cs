using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class UserService : IUserService
    {
        IRepository<User> userRepository;
        IOperationResult operationResult;

        static string userExist = "User exist";
        static string userNotExist = "UserNotExist";

        public UserService(IRepository<User> userRepository, IOperationResult operationResult)
        {
            this.userRepository = userRepository;
            this.operationResult = operationResult;
        }

        public IOperationResult CreateUser(User user)
        {
            if(this.userRepository.Exist(x => x.Name == user.Name))
            {
                SetValueToOperatopnResult(false, userExist);
                return this.operationResult;
            }
            else
            {
                this.userRepository.Add(user);
                SetValueToOperatopnResult(true, userNotExist);
                return this.operationResult;
            }
        }

        public IOperationResult UpdateUser(User user)
        {
            if (!this.userRepository.Exist(x => x.Id == user.Id))
            {
                SetValueToOperatopnResult(false, userNotExist);
                return this.operationResult;
            }
            else
            {
                this.userRepository.Update(user);
                SetValueToOperatopnResult(true, userExist);
                return this.operationResult;
            }
        }

        public IOperationResult Delete(Guid id)
        {
            if (!this.userRepository.Exist(x => x.Id == id))
            {
                SetValueToOperatopnResult(false, userNotExist);
                return this.operationResult;
            }
            else
            {
                this.userRepository.Delete(id);
                SetValueToOperatopnResult(true, userExist);
                return this.operationResult;
            }
        }

        public User GetUser(Guid id)
        {
            if (this.userRepository.Exist(x => x.Id == id))
            {
                return this.userRepository.Get(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        private void SetValueToOperatopnResult(bool isSuccess, string message)
        {
            this.operationResult.IsSucceed = isSuccess;
            this.operationResult.Message = message;
        }
    }
}
