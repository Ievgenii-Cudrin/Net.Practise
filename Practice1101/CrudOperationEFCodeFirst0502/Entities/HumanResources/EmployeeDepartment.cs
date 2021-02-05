using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.HumanResources
{
    public class EmployeeDepartment
    {
        public int EmployeeDepartmentID { get; set; }

        public int BusinessEntityID { get; set; }

        public int DepartmentID { get; set; }

        public int ShiftID { get; set; }

        public DateTime StartDateDocument { get; set; }

        public DateTime EndStateDocument { get; set; }

        public Department Department { get; set; }

        public Shift Shift { get; set; } 

        public Employee Employee { get; set; }
    }
}
