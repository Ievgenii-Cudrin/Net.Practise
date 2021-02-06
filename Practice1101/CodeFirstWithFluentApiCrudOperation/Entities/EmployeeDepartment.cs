using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class EmployeeDepartment
    {
        public DateTime StartDateDocument { get; set; }

        public DateTime EndStateDocument { get; set; }

        public int BusinessEntityID { get; set; }

        public Employee Employee { get; set; }
    }
}
