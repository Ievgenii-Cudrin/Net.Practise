using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetEmployeeByPredicate(Expression<Func<Person, bool>> predicat);

        Person Get(int id);

        void Create(Person item);

        void Update(Person item);

        void Delete(int id);
    }
}
