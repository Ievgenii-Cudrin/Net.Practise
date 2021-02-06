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
            PersonView.CreatePerson();

            Console.Read();
        }
    }
}
