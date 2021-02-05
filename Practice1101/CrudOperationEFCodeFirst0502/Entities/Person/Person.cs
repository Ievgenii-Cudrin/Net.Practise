using CrudOperationEFCodeFirst0502.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.Pers
{
    public class Person
    {
        public int PersonID { get; set; }

        public string PersonType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public List<Employee> Employees { get; set; }
    }
}
