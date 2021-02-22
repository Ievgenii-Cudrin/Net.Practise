using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using Microsoft.Extensions.DependencyInjection;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class JobCandidateView
    {
        static IJobCandidateService jobCandidateService = Startup.ConfigureService().GetRequiredService<IJobCandidateService>();

        public static void CreateJobCandidate()
        {
            JobCandidate jobCandidate = new JobCandidate()
            {
                BusinessEntityId = 5,
                Resume = "resume 1"
            };

            JobCandidate jobCandidate1 = new JobCandidate()
            {
                BusinessEntityId = 6,
                Resume = "resume 2"
            };

            jobCandidateService.CreateJobCandidate(jobCandidate);
            jobCandidateService.CreateJobCandidate(jobCandidate1);
            Console.WriteLine("JobCandidate added");
        }

        public static void UpdateJobCandidate(int id)
        {
            JobCandidate jobCandidate = jobCandidateService.GetJobCandidate(id);

            jobCandidate.Resume = "resume after update";

            jobCandidateService.UpdateJobCandidate(jobCandidate);
            Console.WriteLine("JobCandidate updated");
        }

        public static void ShowAllJobCandidate()
        {
            foreach (var jobCandidate in jobCandidateService.GetAllJobCandidates().ToList())
            {
                Console.WriteLine($"{jobCandidate.JobCandidateId}. {jobCandidate.Resume}, {jobCandidate.BusinessEntityId}");
            }
        }

        public static void DeleteJobCandidate(int id)
        {
            jobCandidateService.DeleteJobCandidate(id);
            Console.WriteLine("JobCandidate deleted");
        }
    }
}
