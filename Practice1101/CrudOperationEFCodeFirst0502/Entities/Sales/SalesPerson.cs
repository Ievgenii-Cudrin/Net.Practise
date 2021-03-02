using CrudOperationEFCodeFirst0502.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationEFCodeFirst0502.Entities.Sales
{
    public class SalesPerson
    {
        public int SalesPersonID { get; set; }

        public int BusinessEntitiID { get; set; }

        public int SalesQuota { get; set; }

        public Employee Employee { get; set; }
    }
}
