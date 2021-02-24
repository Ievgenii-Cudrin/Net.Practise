using CodeFirstWithFluentApiCrudOperation.Interfaces;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        EfCodeFirstWithFluentApiContext db = new EfCodeFirstWithFluentApiContext();

        public void Create(Person item)
        {
            this.db.Persons.Add(item);
            this.db.SaveChanges();
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
