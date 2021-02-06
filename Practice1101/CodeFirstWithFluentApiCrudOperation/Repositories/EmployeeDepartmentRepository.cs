using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmenRepository
    {
        ApplicationContext db;

        public EmployeeDepartmentRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(EmployeeDepartmen item)
        {
            this.db.EmployeeDepartmen.Add(item);
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

        public IEnumerable<EmployeeDepartmen> GetAll()
        {
            return this.db.EmployeeDepartmen.ToList();
        }

        public void Update(EmployeeDepartmen item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
