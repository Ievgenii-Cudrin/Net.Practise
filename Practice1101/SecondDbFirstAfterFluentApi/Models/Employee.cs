using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartmen = new HashSet<EmployeeDepartman>();
            JobCandidates = new HashSet<JobCandidate>();
            SalesPeople = new HashSet<SalesPerson>();
        }

        public int BusinessEntityId { get; set; }
        public int NationalIdnumber { get; set; }
        public int LoginId { get; set; }
        public int OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual EmployeePayHistory EmployeePayHistory { get; set; }
        public virtual ICollection<EmployeeDepartman> EmployeeDepartmen { get; set; }
        public virtual ICollection<JobCandidate> JobCandidates { get; set; }
        public virtual ICollection<SalesPerson> SalesPeople { get; set; }
    }
}
