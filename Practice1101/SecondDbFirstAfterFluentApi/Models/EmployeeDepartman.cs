using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class EmployeeDepartman
    {
        public DateTime StartDateDocument { get; set; }
        public DateTime EndStateDocument { get; set; }
        public int BusinessEntityId { get; set; }
        public int ShiftId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Employee BusinessEntity { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
