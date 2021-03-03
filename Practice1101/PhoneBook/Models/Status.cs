using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class Status
    {
        public Guid Id { get; set; }

        public string RecordStatus { get; set; }

        public List<Record> Records { get; set; }
    }
}
