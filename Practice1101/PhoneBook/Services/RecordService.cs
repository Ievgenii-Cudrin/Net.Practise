using Microsoft.AspNetCore.Authorization;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    [Authorize]
    public class RecordService : IRecordService
    {
        IRepository<Record> recordRepository;
        IOperationResult operationResult;
        private IAuthorizedUser authorizedUser;
        private IUserService userService;

        static string recordExist = "Record exist";
        static string recordNotExist = "Record not exist";

        public RecordService(IRepository<Record> recordRepository, 
            IOperationResult operationResult,
            IAuthorizedUser authorizedUser,
            IUserService userService)
        {
            this.recordRepository = recordRepository;
            this.operationResult = operationResult;
            this.authorizedUser = authorizedUser;
            this.userService = userService;
        }

        public IOperationResult CreateRecord(Record record)
        {
            if (this.recordRepository.Exist(x => x.FullName == record.FullName))
            {
                SetValueToOperatopnResult(false, recordExist);
                return this.operationResult;
            }
            else
            {
                this.recordRepository.Add(record);
                this.authorizedUser.User.Records.Add(record);
                this.userService.UpdateUser(this.authorizedUser.User);
                SetValueToOperatopnResult(true, recordNotExist);
                return this.operationResult;
            }
        }

        public IOperationResult UpdateRecord(Record record)
        {
            if (!this.recordRepository.Exist(x => x.Id == record.Id))
            {
                SetValueToOperatopnResult(false, recordNotExist);
                return this.operationResult;
            }
            else
            {
                this.recordRepository.Update(record);
                SetValueToOperatopnResult(true, recordExist);
                return this.operationResult;
            }
        }

        public IOperationResult DeleteRecord(Guid id)
        {
            if (!this.recordRepository.Exist(x => x.Id == id))
            {
                SetValueToOperatopnResult(false, recordNotExist);
                return this.operationResult;
            }
            else
            {
                this.recordRepository.Delete(id);
                SetValueToOperatopnResult(true, recordExist);
                return this.operationResult;
            }
        }

        public Record GetRecord(Guid id)
        {
            if (this.recordRepository.Exist(x => x.Id == id))
            {
                return this.recordRepository.Get(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public int GetCountOfRecords()
        {
            return this.recordRepository.Count();
        }

        public List<Record> GetRecordsForOnePage(int skip, int take)
        {
            return this.recordRepository.GetPageWithInclude(x => x.User, skip, take).ToList();
        }

        private void SetValueToOperatopnResult(bool isSuccess, string message)
        {
            this.operationResult.IsSucceed = isSuccess;
            this.operationResult.Message = message;
        }
    }
}
