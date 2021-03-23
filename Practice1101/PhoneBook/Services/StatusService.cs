using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class StatusService : IStatusService
    {
        IRepository<Status> statusRepository;
        IOperationResult operationResult;

        static string userExist = "User exist";
        static string userNotExist = "UserNotExist";

        public StatusService(IRepository<Status> statusRepository, IOperationResult operationResult)
        {
            this.statusRepository = statusRepository;
            this.operationResult = operationResult;
        }

        public Status GetStatus(Guid id)
        {
            if (this.statusRepository.Exist(x => x.Id == id))
            {
                return this.statusRepository.Get(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public List<Status> GetAllStatuses()
        {
            return this.statusRepository.GetAll().ToList();
        }

        public Status GetStatusByName(string statusName)
        {
            if (!string.IsNullOrEmpty(statusName))
            {
                return this.statusRepository.Get(x => x.RecordStatus == statusName).FirstOrDefault();
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
