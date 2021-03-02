using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IJobCandidateRepository
    {
        IQueryable<JobCandidate> GetEmployeeByPredicate(Expression<Func<JobCandidate, bool>> predicat);

        JobCandidate Get(int id);

        void Create(JobCandidate item);

        void Update(JobCandidate item);

        void Delete(int id);
    }
}
