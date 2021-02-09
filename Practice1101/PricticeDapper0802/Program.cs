using Microsoft.Extensions.DependencyInjection;
using PricticeDapper0802.DI;
using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using PricticeDapper0802.Repositories;
using PricticeDapper0802.Services;
using System;
using System.Text.Json;

namespace PricticeDapper0802
{
    class Program
    {
        static void Main(string[] args)
        {
            IMailService mailService = Startup.ConfigureService().GetRequiredService<IMailService>();
            IUserService userSevice = Startup.ConfigureService().GetRequiredService<IUserService>();
            IDataEncryptor dataEncryptor = Startup.ConfigureService().GetRequiredService<IDataEncryptor>();

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
                To = "Test2@gmail.com",
                From = "Test2@gmail.com",
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

            User firstUser = new User()
            {
                Name = "Fn",
                Surname = "Sn",
                Email = "Test@gmail.com",
                DateOfBirth = DateTime.Now.ToString("yyyy-MM-dd")
            };

            User secondUser = new User()
            {
                Name = "Fn1",
                Surname = "Sn1",
                Email = "Test1@gmail.com",
                DateOfBirth = DateTime.Now.ToString("yyyy-MM-dd")
            };

            userSevice.AddUser(firstUser);
            userSevice.AddUser(secondUser);

            mailService.AddMail(secondMail, 1);
            mailService.AddMail(firstMail, 2);

            //mailService.DeleteMail(1);

            dataEncryptor.EncryptData("Test@gmail.com");

            Console.ReadLine();
        }
    }
}
