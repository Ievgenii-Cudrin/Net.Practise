using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Linq;

namespace CodeFirstWithFluentApiCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Person person = new Person() { FirstName = "FN2", LastName = "LN2" };
                Shift shift = new Shift() { Name = "First", StartTime = DateTime.Now, EndTime = DateTime.Now};
                // добавляем их в бд
                db.Persons.Add(person);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Persons.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Person u in users)
                {
                    Console.WriteLine($"{u.PersonID}.{u.FirstName} - {u.LastName}");
                }
            }
            Console.Read();
        }
    }
}
