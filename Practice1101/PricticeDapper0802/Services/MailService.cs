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
        IUserMailService userMailService;

        public MailService(IRepository<Mail> mailRepo, IUserMailService userMailServ)
        {
            this.mailRepository = mailRepo;
            this.userMailService = userMailServ;
        }

        public void AddMail(Mail mail, int userId)
        {
            this.mailRepository.Add(mail).Wait();
            this.userMailService.Add(userId, mail.Id);
            
        }

        public void UpdateMail(Mail mail)
        {
            this.mailRepository.Update(mail).Wait();
        }

        public List<Mail> GetAllMails()
        {
            return this.mailRepository.FindAll().Result.ToList();
        }

        public void DeleteMail(int id)
        {
            Mail mail = this.mailRepository.FindByID(id).Result;

            if(mail != null)
            {
                this.mailRepository.Delete(mail).Wait();
            }
        }
    }
}
