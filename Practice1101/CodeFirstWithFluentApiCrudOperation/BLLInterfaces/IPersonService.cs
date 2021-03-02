using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IPersonService
    {
        void CreatePerson(Person user);

        List<Person> GetAllPersonByPredicate(Expression<Func<Person, bool>> predicat);

        void UpdatePerson(Person user);

        void DeletePerson(int id);

        Person GetPerson(int id);
    }
}
