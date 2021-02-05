using CrudOperationEFCodeFirst0502.DataContext;
using CrudOperationEFCodeFirst0502.Entities.Pers;
using System;
using System.Linq;

namespace CrudOperationEFCodeFirst0502
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Person person = new Person() { FirstName = "FN", LastName = "LN" };
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
