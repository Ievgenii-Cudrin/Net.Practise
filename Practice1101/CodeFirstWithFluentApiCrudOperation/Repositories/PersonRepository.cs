using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        ApplicationContext db = new ApplicationContext();

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

        public IQueryable<Person> GetEmployeeByPredicate(Expression<Func<Person, bool>> predicat)
        {
            return this.db.Set<Person>().Where(predicat);
        }

        public void Update(Person item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
