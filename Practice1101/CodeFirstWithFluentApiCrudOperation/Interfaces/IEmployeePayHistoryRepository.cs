using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeePayHistoryRepository
    {
        IQueryable<EmployeePayHistory> GetEmployeeByPredicate(Expression<Func<EmployeePayHistory, bool>> predicat);

        EmployeePayHistory Get(int id);

        void Create(EmployeePayHistory item);

        void Update(EmployeePayHistory item);

        void Delete(int id);
    }
}
