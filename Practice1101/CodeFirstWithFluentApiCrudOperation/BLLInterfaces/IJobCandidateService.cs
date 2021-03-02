using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IJobCandidateService
    {
        void CreateJobCandidate(JobCandidate item);

        List<JobCandidate> GetAllJobCandidatesByPredicate(Expression<Func<JobCandidate, bool>> predicat);

        void UpdateJobCandidate(JobCandidate item);

        void DeleteJobCandidate(int id);

        JobCandidate GetJobCandidate(int id);
    }
}
