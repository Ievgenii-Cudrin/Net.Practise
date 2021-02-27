using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public int SalesQuota { get; set; }
        public int BusinessEntityId { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
