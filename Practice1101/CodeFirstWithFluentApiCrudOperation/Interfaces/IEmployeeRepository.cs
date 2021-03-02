using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployeeByPredicate(Expression<Func<Employee, bool>> predicat);

        Employee Get(int id);

        void Create(Employee item);

        void Update(Employee item);

        void Delete(int id);
    }
}
