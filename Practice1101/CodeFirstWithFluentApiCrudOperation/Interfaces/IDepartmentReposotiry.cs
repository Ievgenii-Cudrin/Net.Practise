using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IDepartmentReposotiry
    {
        IQueryable<Department> GetEmployeeByPredicate(Expression<Func<Department, bool>> predicat);

        Department Get(int id);

        void Create(Department item);

        void Update(Department item);

        void Delete(int id);
    }
}
