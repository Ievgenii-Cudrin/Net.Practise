using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class OperationResult : IOperationResult
    {
        public string Message { get; set; }

        public bool IsSucceed { get; set; }
    }
}
