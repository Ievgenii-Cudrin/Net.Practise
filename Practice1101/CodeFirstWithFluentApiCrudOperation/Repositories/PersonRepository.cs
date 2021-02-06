using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        ApplicationContext db;

        public PersonRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Person item)
        {
            this.db.Persons.Add(item);
        }

        public void Delete(int id)
        {
            Person item = db.Persons.FirstOrDefault();
            if (item != null)
            {
                this.db.Persons.Remove(item);
                this.db.SaveChanges();
            }
        }

        public Person Get(int id)
        {
            return this.db.Persons.Find(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return this.db.Persons.ToList();
        }

        public void Update(Person item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
