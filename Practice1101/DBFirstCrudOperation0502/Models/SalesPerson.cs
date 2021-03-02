using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public int BusinessEntitiId { get; set; }
        public int SalesQuota { get; set; }
        public int? EmployeeBusinessEntityId { get; set; }

        public virtual Employee EmployeeBusinessEntity { get; set; }
    }
}
