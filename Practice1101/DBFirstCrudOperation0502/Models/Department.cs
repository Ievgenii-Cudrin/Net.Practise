using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class Department
    {
        public Department()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
