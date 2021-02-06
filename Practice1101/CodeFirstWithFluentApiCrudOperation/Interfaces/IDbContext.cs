using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeDepartmen> EployeeDepartmen { get; set; }

        public DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }

        public DbSet<JobCandidate> JobCandidate { get; set; }

        public DbSet<SalesPerson> SalesPerson { get; set; }

        public DbSet<Shift> Shift { get; set; }
    }
}
