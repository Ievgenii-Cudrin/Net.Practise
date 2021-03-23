using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IStatusService
    {
        Status GetStatus(Guid id);

        List<Status> GetAllStatuses();

        Status GetStatusByName(string statusName);
    }
}
