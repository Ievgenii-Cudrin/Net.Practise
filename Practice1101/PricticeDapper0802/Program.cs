using PricticeDapper0802.Entities;
using PricticeDapper0802.Repositories;
using System;
using System.Text.Json;

namespace PricticeDapper0802
{
    class Program
    {
        static void Main(string[] args)
        {
            LetterBody firstBody = new LetterBody()
            {
                To = "Test@gmail.com",
                From = "Test@gmail.com",
                Subject = "Test",
                Letter = "Some text",
                Date = DateTime.Now.ToString("yyyy-MM-dd")
            };

            LetterBody secondBody = new LetterBody()
            {
                To = "Test1@gmail.com",
                From = "Test1@gmail.com",
                Subject = "Test1",
                Letter = "Some text",
                Date = DateTime.Now.ToString("yyyy-MM-dd")
            };


            Mail firstMail = new Mail()
            {
                Object = JsonSerializer.Serialize(firstBody)
            };

            Mail secondMail = new Mail()
            {
                Object = JsonSerializer.Serialize(secondBody)
            };

            User user = new User()
            {
                Name = "Fn",
                Surname = "Sn",
                DateOfBirth = DateTime.Now
            };

            Repository<Mail> mailRepo = new Repository<Mail>();
            //mailRepo.Add(firstMail).Wait();
            //mailRepo.Add(secondMail).Wait();

            Repository<User> userRepo = new Repository<User>();
            //userRepo.Add(user).Wait();

            var a = userRepo.FindAll().Result;

            

            string json = JsonSerializer.Serialize(firstBody);
            Console.WriteLine(json);
            
            Console.ReadLine();
        }
    }
}
