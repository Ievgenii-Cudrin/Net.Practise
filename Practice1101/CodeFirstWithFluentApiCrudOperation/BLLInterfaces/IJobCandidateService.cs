using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IJobCandidateService
    {
        public void CreateJobCandidate(JobCandidate user);

        public List<JobCandidate> GetAllJobCandidates();

        public void UpdateJobCandidate(JobCandidate user);

        public void DeleteJobCandidate(int id);

        public JobCandidate GetJobCandidate(int id);
    }
}
