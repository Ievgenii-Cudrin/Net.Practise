using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class SalesPerson
    {
        public int SalesPersonID { get; set; }

        public int BusinessEntityID { get; set; }

        public int SalesQuota { get; set; }

        public Employee Employee { get; set; }
    }
}
