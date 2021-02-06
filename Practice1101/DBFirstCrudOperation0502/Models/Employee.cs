using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
            EmployeePayHistories = new HashSet<EmployeePayHistory>();
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
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual ICollection<JobCandidate> JobCandidates { get; set; }
        public virtual ICollection<SalesPerson> SalesPeople { get; set; }
    }
}
