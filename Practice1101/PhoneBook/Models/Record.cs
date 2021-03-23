using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class Record
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastChangeDate { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid StatusId { get; set; }

        public Status Status { get; set; }
    }
}
