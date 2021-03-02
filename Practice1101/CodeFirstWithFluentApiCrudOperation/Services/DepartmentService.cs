using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentReposotiry departmentReposotiry;

        public DepartmentService(IDepartmentReposotiry departmentReposotiry)
        {
            this.departmentReposotiry = departmentReposotiry;
        }
        public void CreateDepartment(Department item)
        {
            this.departmentReposotiry.Create(item);
        }

        public void DeleteDepartment(int id)
        {
            this.departmentReposotiry.Delete(id);
        }

        public List<Department> GetDepartments(Expression<Func<Department, bool>> predicat)
        {
            return this.departmentReposotiry.GetEmployeeByPredicate(predicat).ToList();
        }

        public Department GetDepartment(int id)
        {
            return this.departmentReposotiry.Get(id);
        }

        public void UpdateDepartment(Department item)
        {
            this.departmentReposotiry.Update(item);
        }
    }
}
