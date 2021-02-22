using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Entities
{
    public class JobCandidate
    {
        public int JobCandidateID { get; set; }

        public string Resume { get; set; }

        public int BusinessEntityID { get; set; }

        public Employee Employee { get; set; }
    }
}
