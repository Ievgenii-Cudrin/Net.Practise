using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class Shift
    {
        public Shift()
        {
            EmployeeDepartmen = new HashSet<EmployeeDepartman>();
        }

        public int ShiftId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<EmployeeDepartman> EmployeeDepartmen { get; set; }
    }
}
