using PricticeDapper0802.Entities;
using PricticeDapper0802.Repositories;
using System;

namespace PricticeDapper0802
{
    class Program
    {
        static void Main(string[] args)
        {
            Mail mail = new Mail()
            {
                Object = @"{
                            'To': 'Test@gmail.com'
                            'From': 'Test@gmail.com',
                            'Subject': 'Test',
                            'Letter': 'Some text',
                            'Date': '2021-01-05'
                           }"
            };

            User user = new User()
            {
                Name = "Fn",
                Surname = "Sn",
                DateOfBirth = DateTime.Now
            };

            Repository<Mail> mailRepo = new Repository<Mail>();
            mailRepo.Add(mail).Wait();

            Repository<User> userRepo = new Repository<User>();
            userRepo.Add(user).Wait();

            var a = userRepo.FindAll().Result;

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
