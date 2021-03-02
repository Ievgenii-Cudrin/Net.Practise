using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.HumanResources
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
