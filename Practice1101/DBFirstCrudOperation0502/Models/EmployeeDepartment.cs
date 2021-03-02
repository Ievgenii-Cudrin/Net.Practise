using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class EmployeeDepartment
    {
        public int EmployeeDepartmentId { get; set; }
        public int BusinessEntityId { get; set; }
        public int DepartmentId { get; set; }
        public int ShiftId { get; set; }
        public DateTime StartDateDocument { get; set; }
        public DateTime EndStateDocument { get; set; }
        public int? EmployeeBusinessEntityId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee EmployeeBusinessEntity { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
