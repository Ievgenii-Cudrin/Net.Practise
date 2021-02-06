using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class EmployeePayHistory
    {
        public int EmployeePayHistoryId { get; set; }

        public DateTime RateChangeDate { get; set; }

        public int Rate { get; set; }

        public int PayFrequency { get; set; }

        public int BusinessEntityID { get; set; }

        public Employee Employee { get; set; }
    }
}
