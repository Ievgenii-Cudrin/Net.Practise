using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmenRepository
    {
        ApplicationContext db = new ApplicationContext();

        public void Create(EmployeeDepartmen item)
        {
            this.db.Database.OpenConnection();
            try
            {
                this.db.EmployeeDepartmen.Add(item);
                this.db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT EmployeeDepartmen ON");
                this.db.SaveChanges();
                this.db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT EmployeeDepartmen OFF");
            }
            finally
            {
                this.db.SaveChanges();
                this.db.Database.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            EmployeeDepartmen employeeDepartment = db.EmployeeDepartmen.FirstOrDefault();
            if (employeeDepartment != null)
            {
                this.db.EmployeeDepartmen.Remove(employeeDepartment);
                this.db.SaveChanges();
            }
        }

        public EmployeeDepartmen Get(int id)
        {
            return this.db.EmployeeDepartmen.Find(id);
        }

        public void Update(EmployeeDepartmen item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }

        public IQueryable<EmployeeDepartmen> GetEmployeeByPredicate(Expression<Func<EmployeeDepartmen, bool>> predicat)
        {
            return this.db.Set<EmployeeDepartmen>().Where(predicat);
        }
    }
}
