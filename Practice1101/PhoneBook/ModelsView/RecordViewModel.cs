using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.ModelsView
{
    public class RecordViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string RecordStatus { get; set; }

        public UserViewModel User { get; set; }

        public Status Status { get; set; }
    }
}
