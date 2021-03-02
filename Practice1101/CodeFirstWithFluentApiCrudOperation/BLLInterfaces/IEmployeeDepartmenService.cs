using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeeDepartmenService
    {
        void CreateEmployeeDepartmen(EmployeeDepartmen item);

        List<EmployeeDepartmen> GetEmployeeDepartmensByPredicate(Expression<Func<EmployeeDepartmen, bool>> predicat);

        void UpdateEmployeeDepartmen(EmployeeDepartmen item);

        void DeleteEmployeeDepartmen(int id);

        EmployeeDepartmen GetEmployeeDepartmen(int id);
    }
}
