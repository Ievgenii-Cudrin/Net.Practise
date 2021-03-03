using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class OperationResultService : IOperationResult
    {
        OperationResult operationResult;
        public OperationResult OperationResult
        {
            get
            {
                if(operationResult == null)
                {
                    operationResult = new OperationResult();
                }

                return operationResult;
            }
            set
            {
                operationResult = value;
            }
        }
    }
}
