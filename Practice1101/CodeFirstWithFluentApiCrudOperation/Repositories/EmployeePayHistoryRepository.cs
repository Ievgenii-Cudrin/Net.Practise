using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeePayHistoryRepository : IEmployeePayHistoryRepository
    {
        ApplicationContext db = new ApplicationContext();
        public void Create(EmployeePayHistory item)
        {
            this.db.EmployeePayHistory.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            EmployeePayHistory employeeDepartment = db.EmployeePayHistory.FirstOrDefault();
            if (employeeDepartment != null)
            {
                this.db.EmployeePayHistory.Remove(employeeDepartment);
                this.db.SaveChanges();
            }
        }

        public EmployeePayHistory Get(int id)
        {
            return this.db.EmployeePayHistory.Find(id);
        }

        public void Update(EmployeePayHistory item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }

        public IQueryable<EmployeePayHistory> GetEmployeeByPredicate(Expression<Func<EmployeePayHistory, bool>> predicat)
        {
            return this.db.Set<EmployeePayHistory>().Where(predicat);
        }
    }
}
