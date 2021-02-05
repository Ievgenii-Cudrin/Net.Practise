using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.HumanResources
{
    public class Shift
    {
        public int ShiftID { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
