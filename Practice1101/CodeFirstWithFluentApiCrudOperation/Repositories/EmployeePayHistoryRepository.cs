using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeePayHistoryRepository : IEmployeePayHistoryRepository
    {
        ApplicationContext db;

        public EmployeePayHistoryRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(EmployeePayHistory item)
        {
            this.db.EmployeePayHistory.Add(item);
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

        public IEnumerable<EmployeePayHistory> GetAll()
        {
            return this.db.EmployeePayHistory.ToList();
        }

        public void Update(EmployeePayHistory item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
