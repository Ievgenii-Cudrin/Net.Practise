using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class Person
    {
        public int PersonID { get; set; }

        public string PersonType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
