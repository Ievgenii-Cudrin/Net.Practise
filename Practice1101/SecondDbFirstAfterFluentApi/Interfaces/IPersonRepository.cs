using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IPersonRepository
    {
        public IEnumerable<Person> GetAll();

        public Person Get(int id);

        public void Create(Person item);

        public void Update(Person item);

        public void Delete(int id);
    }
}
