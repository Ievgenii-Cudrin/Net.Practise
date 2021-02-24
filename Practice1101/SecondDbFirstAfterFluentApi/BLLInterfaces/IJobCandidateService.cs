using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IJobCandidateService
    {
        public void CreateJobCandidate(JobCandidate item);

        public List<JobCandidate> GetAllJobCandidates();

        public void UpdateJobCandidate(JobCandidate item);

        public void DeleteJobCandidate(int id);

        public JobCandidate GetJobCandidate(int id);
    }
}
