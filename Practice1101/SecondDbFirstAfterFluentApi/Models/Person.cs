using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class Person
    {
        public Person()
        {
            Employees = new HashSet<Employee>();
        }

        public int PersonId { get; set; }
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
