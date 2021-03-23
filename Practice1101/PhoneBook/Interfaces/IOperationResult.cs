﻿using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IOperationResult
    {
        string Message { get; set; }

        bool IsSucceed { get; set; }
    }
}
