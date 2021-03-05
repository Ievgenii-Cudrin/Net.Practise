using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IStatusService
    {
        IOperationResult CreateStatus(Status status);

        IOperationResult UpdateStatus(Status status);

        IOperationResult Delete(Guid id);

        Status GetUser(Guid id);

        List<Status> GetAllStatuses();

        Status GetStatusByName(string statusName);
    }
}
