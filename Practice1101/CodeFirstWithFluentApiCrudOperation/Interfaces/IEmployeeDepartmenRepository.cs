using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeeDepartmenRepository
    {
        IQueryable<EmployeeDepartmen> GetEmployeeByPredicate(Expression<Func<EmployeeDepartmen, bool>> predicat);

        EmployeeDepartmen Get(int id);

        void Create(EmployeeDepartmen item);

        void Update(EmployeeDepartmen item);

        void Delete(int id);
    }
}
