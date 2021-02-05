using CrudOperationEFCodeFirst0502.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using CrudOperationEFCodeFirst0502.Entities.Pers;

namespace CrudOperationEFCodeFirst0502.Entities.HumanResources
{
    public class Employee
    {
        public int BusinessEnrirtID { get; set; }

        public int NationalIDNumber { get; set; }

        public int LoginID { get; set; }

        public int OrganizationLevel { get; set; }

        public string JobTitle { get; set; }

        public List<SalesPerson> SalesPersons { get; set; }

        public List<EmployeePayHistory> EmployeePayHistories { get; set; }

        public List<JobCandidate> JobCandidates { get; set; }

        public List<EmployeeDepartment> EmployeeDepartments { get; set; }

        public int PersonID { get; set; }

        public Person Person { get; set; }
    }
}
