using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using CodeFirstWithFluentApiCrudOperation.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.DI
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IDepartmentReposotiry, DepartmentRepository>()
                .AddTransient<IEmployeeDepartmenRepository, EmployeeDepartmentRepository>()
                .AddTransient<IEmployeePayHistoryRepository, EmployeePayHistoryRepository>()
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IJobCandidateRepository, JobCandidateRepository>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddTransient<ISalesPersonRepository, SalesPersonRepository>()
                .AddTransient<IShiftRepository, ShiftRepository>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
