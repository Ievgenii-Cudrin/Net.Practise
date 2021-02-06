using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class DepartmentRepository : IDepartmentReposotiry
    {
        ApplicationContext db;

        public DepartmentRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Department item)
        {
            this.db.Department.Add(item);
        }

        public void Delete(int id)
        {
            Department department = db.Department.FirstOrDefault();
            if (department != null)
            {
                this.db.Department.Remove(department);
                this.db.SaveChanges();
            }
        }

        public Department Get(int id)
        {
            return this.db.Department.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return this.db.Department.ToList();
        }

        public void Update(Department item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
