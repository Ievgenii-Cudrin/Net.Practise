﻿using CodeFirstWithFluentApiCrudOperation.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmenRepository
    {
        EfCodeFirstWithFluentApiContext db = new EfCodeFirstWithFluentApiContext();

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
