using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class JobCandidateService : IJobCandidateService
    {
        IJobCandidateRepository jobCandidateRepository;

        public JobCandidateService(IJobCandidateRepository jobCandidateRepository)
        {
            this.jobCandidateRepository = jobCandidateRepository;
        }

        public void CreateJobCandidate(JobCandidate item)
        {
            this.jobCandidateRepository.Create(item);
        }

        public void DeleteJobCandidate(int id)
        {
            this.jobCandidateRepository.Delete(id);
        }

        public List<JobCandidate> GetAllJobCandidatesByPredicate(Expression<Func<JobCandidate, bool>> predicat)
        {
            return this.jobCandidateRepository.GetEmployeeByPredicate(predicat).ToList();
        }

        public JobCandidate GetJobCandidate(int id)
        {
            return this.jobCandidateRepository.Get(id);
        }

        public void UpdateJobCandidate(JobCandidate item)
        {
            this.jobCandidateRepository.Update(item);
        }
    }
}
