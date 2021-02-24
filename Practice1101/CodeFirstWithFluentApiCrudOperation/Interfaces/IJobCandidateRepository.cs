using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IJobCandidateRepository
    {
        public IEnumerable<JobCandidate> GetAll();

        public JobCandidate Get(int id);

        public void Create(JobCandidate item);

        public void Update(JobCandidate item);

        public void Delete(int id);
    }
}
