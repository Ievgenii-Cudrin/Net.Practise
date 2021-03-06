﻿using CodeFirstWithFluentApiCrudOperation.DataContext;
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
        ApplicationContext db = new ApplicationContext();

        public void Create(Department item)
        {
            this.db.Department.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            Department item = db.Department.FirstOrDefault();
            if (item != null)
            {
                this.db.Department.Remove(item);
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
