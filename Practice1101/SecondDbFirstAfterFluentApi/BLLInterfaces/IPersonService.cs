using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IPersonService
    {
        public void CreatePerson(Person user);

        public List<Person> GetAllPerson();

        public void UpdatePerson(Person user);

        public void DeletePerson(int id);

        public Person GetPerson(int id);
    }
}
