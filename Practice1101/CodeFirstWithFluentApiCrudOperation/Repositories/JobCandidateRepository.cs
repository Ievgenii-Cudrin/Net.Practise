using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        ApplicationContext db = new ApplicationContext();
        public void Create(JobCandidate item)
        {
            this.db.JobCandidate.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            JobCandidate candidate = db.JobCandidate.FirstOrDefault();
            if (candidate != null)
            {
                this.db.JobCandidate.Remove(candidate);
                this.db.SaveChanges();
            }
        }

        public JobCandidate Get(int id)
        {
            return this.db.JobCandidate.Find(id);
        }

        public IEnumerable<JobCandidate> GetAll()
        {
            return this.db.JobCandidate.ToList();
        }

        public void Update(JobCandidate item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
