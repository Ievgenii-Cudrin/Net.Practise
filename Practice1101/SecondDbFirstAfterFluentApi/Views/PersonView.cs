using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using Microsoft.Extensions.DependencyInjection;
using SecondDbFirstAfterFluentApi.Models;
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

        public static void ShowAllPersons()
        {
            foreach(var person in personService.GetAllPerson().ToList())
            {
                Console.WriteLine($"{person.PersonId}. {person.FirstName} {person.LastName}");
            }
        }

        public static void DeletePerson(int id)
        {
            personService.DeletePerson(id);
            Console.WriteLine("Person deleted");
        }
    }
}
