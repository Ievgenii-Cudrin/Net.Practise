using System;
using System.Collections.Generic;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class JobCandidate
    {
        public int JobCandidateId { get; set; }
        public string Resume { get; set; }
        public int BusinessEntityId { get; set; }
        public int? EmployeeBusinessEntityId { get; set; }

        public virtual Employee EmployeeBusinessEntity { get; set; }
    }
}
