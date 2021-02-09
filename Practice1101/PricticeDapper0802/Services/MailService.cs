using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PricticeDapper0802.Services
{
    public class MailService : IMailService
    {
        IRepository<Mail> mailRepository;
        IRepository<UserMail> userMailRepository;
        IRepository<User> userRepository;

        public MailService(IRepository<Mail> mailRepo)
        {
            this.mailRepository = mailRepo;
            //this.userMailRepository = userMailRepo;
            //this.userRepository = userRepo;
        }

        public void AddMail(Mail mail, int userId)
        {

            //if(this.userRepository.FindByID(userId) != null)
            //{

            //}
            this.mailRepository.Add(mail).Wait();

            int id = mail.Id;
        }

        public void UpdateMail(Mail mail)
        {
            this.mailRepository.Update(mail).Wait();
        }

        public List<Mail> GetAllMails()
        {
            return this.mailRepository.FindAll().Result.ToList();
        }
    }
}
