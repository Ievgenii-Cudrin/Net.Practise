using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IDepartmentService
    {
        void CreateDepartment(Department item);

        List<Department> GetDepartments(Expression<Func<Department, bool>> predicat);

        void UpdateDepartment(Department item);

        void DeleteDepartment(int id);

        Department GetDepartment(int id);
    }
}
