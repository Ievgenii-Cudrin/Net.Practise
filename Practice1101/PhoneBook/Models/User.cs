using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Record> Records { get; set; }

        public User()
        {
            Records = new List<Record>();
        }
    }
}
