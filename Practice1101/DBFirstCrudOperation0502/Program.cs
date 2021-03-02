using DBFirstCrudOperation0502.Models;
using System;
using System.Linq;

namespace DBFirstCrudOperation0502
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfCodeFirstContext db = new EfCodeFirstContext())
            {
                Person person = new Person() { FirstName = "FN1", LastName = "LN1" };
                // добавляем их в бд
                db.Persons.Add(person);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Persons.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Person u in users)
                {
                    Console.WriteLine($"{u.PersonId}.{u.FirstName} - {u.LastName}");
                }
            }
            Console.Read();
        }
    }
}
