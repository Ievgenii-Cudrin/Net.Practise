using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationContext db = new ApplicationContext();
        public void Create(Employee item)
        {
            this.db.Employee.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee employee = db.Employee.FirstOrDefault();
            if (employee != null)
            {
                this.db.Employee.Remove(employee);
                this.db.SaveChanges();
            }
        }

        public Employee Get(int id)
        {
            return this.db.Employee.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.db.Employee.ToList();
        }

        public void Update(Employee item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
