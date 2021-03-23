using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IRecordService
    {
        IOperationResult CreateRecord(Record record);

        IOperationResult UpdateRecord(Record record);

        IOperationResult DeleteRecord(Guid id);

        Record GetRecord(Guid id);

        int GetCountOfRecords();

        List<Record> GetRecordsForOnePage(int skip, int take);
    }
}
