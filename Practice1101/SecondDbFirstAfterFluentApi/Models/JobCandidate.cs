using System;
using System.Collections.Generic;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class JobCandidate
    {
        public int JobCandidateId { get; set; }
        public string Resume { get; set; }
        public int BusinessEntityId { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
