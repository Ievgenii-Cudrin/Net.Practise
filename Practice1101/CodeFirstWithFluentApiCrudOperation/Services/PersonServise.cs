using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public void CreatePerson(Person user)
        {
            this.personRepository.Create(user);
        }

        public void DeletePerson(int id)
        {
            this.personRepository.Delete(id);
        }

        public List<Person> GetAllPersonByPredicate(Expression<Func<Person, bool>> predicat)
        {
            return this.personRepository.GetEmployeeByPredicate(predicat).ToList();
        }

        public Person GetPerson(int id)
        {
            return this.personRepository.Get(id);
        }

        public void UpdatePerson(Person user)
        {
            this.personRepository.Update(user);
        }
    }
}
