using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class Shift
    {
        public Shift()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
        }

        public int ShiftId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
