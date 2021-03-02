using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee item);

        List<Employee> GetAllEmployeesByPredicate(Expression<Func<Employee, bool>> predicat);

        void UpdateEmployee(Employee item);

        void DeleteEmployee(int id);

        Employee GetEmployee(int id);
    }
}
