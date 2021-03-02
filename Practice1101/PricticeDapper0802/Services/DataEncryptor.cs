using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace PricticeDapper0802.Services
{
    public class DataEncryptor : IDataEncryptor
    {
        IUserService userService;
        IMailService mailService;

        public DataEncryptor(IUserService userServ, IMailService mailServ)
        {
            this.userService = userServ;
            this.mailService = mailServ;
        }

        public void EncryptData(string email)
        {
            int countOfEmail = this.mailService.GetCountOfEmailTableRows();

            for(int i = 1; i < countOfEmail/10 + 1; i++)
            {
                Pager pager = new Pager(i);
                List<Mail> mails = this.mailService.GetAllMailsInPage(pager, "Emails");
                EncryptUserData(email);
                EncryprtToInMail(mails, email);
                EncryprtToFromMail(mails, email);
            }
        }

        private void EncryptUserData(string email)
        {
            User user = this.userService.GetUserByEmail(email);

            if (user != null)
            {
                user.Name = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Name));
                user.Surname = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Surname));
                user.Email = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Email));
                user.DateOfBirth = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.DateOfBirth));

                this.userService.UpdateUser(user);
            }
        }

        private void EncryprtToInMail(List<Mail> mails, string email)
        {
            foreach (var mail in mails)
            {
                LetterBody body = JsonSerializer.Deserialize<LetterBody>(mail.Object);

                if (body.To == email)
                {
                    body.To = Convert.ToBase64String(Encoding.UTF8.GetBytes(body.To));
                    mail.Object = JsonSerializer.Serialize(body);
                    this.mailService.UpdateMail(mail);
                }
            }
        }

        private void EncryprtToFromMail(List<Mail> mails, string email)
        {
            foreach (var mail in mails)
            {
                LetterBody body = JsonSerializer.Deserialize<LetterBody>(mail.Object);

                if (body.From == email)
                {
                    body.From = Convert.ToBase64String(Encoding.UTF8.GetBytes(body.From));
                    mail.Object = JsonSerializer.Serialize(body);
                    this.mailService.UpdateMail(mail);
                }
            }
        }
    }
}
