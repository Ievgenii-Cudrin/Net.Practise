using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.HumanResources
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
