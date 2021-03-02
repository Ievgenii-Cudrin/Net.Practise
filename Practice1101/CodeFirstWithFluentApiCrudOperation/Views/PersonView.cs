using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class PersonView
    {
        static IPersonService personService = Startup.ConfigureService().GetRequiredService<IPersonService>();

        public static void CreatePerson()
        {
            Person person = new Person()
            {
                FirstName = "John",
                LastName = "Lennon",
                PersonType = "European"
            };

            personService.CreatePerson(person);
            Console.WriteLine("Person added");
        }

        public static void UpdatePerson(int id)
        {
            Person person = personService.GetPerson(id);

            person.FirstName = "JohnNewName";
            person.LastName = "LennonNewLatsName";
            person.PersonType = "EuropeanNewType";

            personService.UpdatePerson(person);
            Console.WriteLine("Person updated");
        }

        public static void DeletePerson(int id)
        {
            personService.DeletePerson(id);
            Console.WriteLine("Person deleted");
        }
    }
}
