using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class Employee
    {
        public int BusinessEntityID { get; set; }

        public int NationalIDNumber { get; set; }

        public int LoginID { get; set; }

        public int OrganizationLevel { get; set; }

        public string JobTitle { get; set; }

        public int PersonID { get; set; }

        public Person Person { get; set; }

        public List<JobCandidate> JobCandidates { get; set; }

        public List<SalesPerson> SalesPersons { get; set; }
    }
}
