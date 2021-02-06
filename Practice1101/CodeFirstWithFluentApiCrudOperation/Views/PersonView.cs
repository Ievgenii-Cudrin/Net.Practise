using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
    }
}
