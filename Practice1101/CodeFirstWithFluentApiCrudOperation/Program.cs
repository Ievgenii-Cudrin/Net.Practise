using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Views;
using System;
using System.Linq;

namespace CodeFirstWithFluentApiCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            //PersonView.CreatePerson();
            //PersonView.UpdatePerson(1);
            //PersonView.DeletePerson(4);
            PersonView.ShowAllPersons();

            Console.Read();
        }
    }
}
