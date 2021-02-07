using CodeFirstWithFluentApiCrudOperation.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class DepartmentRepository : IDepartmentReposotiry
    {
        EfCodeFirstWithFluentApiContext db = new EfCodeFirstWithFluentApiContext();

        public void Create(Department item)
        {
            this.db.Departments.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Department item = db.Departments.FirstOrDefault();
            if (item != null)
            {
                this.db.Departments.Remove(item);
                this.db.SaveChanges();
            }
        }

        public Department Get(int id)
        {
            return this.db.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return this.db.Departments.ToList();
        }

        public void Update(Department item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
