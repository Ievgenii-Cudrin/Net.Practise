using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class EmployeePayHistory
    {
        public int EmployeePayHistoryId { get; set; }
        public DateTime RateChangeDate { get; set; }
        public int Rate { get; set; }
        public int PayFrequency { get; set; }
        public int BusinessEntityId { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
