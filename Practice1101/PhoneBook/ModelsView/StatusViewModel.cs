using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.ModelsView
{
    public class StatusViewModel
    {
        public Guid Id { get; set; }

        public string RecordStatus { get; set; }

        public List<RecordViewModel> Records { get; set; }
    }
}
