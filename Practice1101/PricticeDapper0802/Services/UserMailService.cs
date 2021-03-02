using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Services
{
    public class UserMailService : IUserMailService
    {
        IRepository<UserMail> userMailRepository;
        IRepository<Mail> mailRepository;
        IRepository<User> userRepository;


        public UserMailService(IRepository<UserMail> userMailRepo, IRepository<Mail> mailRepo, IRepository<User> userRepo)
        {
            this.userMailRepository = userMailRepo;
            this.userRepository = userRepo;
            this.mailRepository = mailRepo;
        }

        public void Add(int userId, int mailId)
        {
            if(this.userRepository.FindByID(userId) != null && this.mailRepository.FindByID(mailId) != null)
            {
                UserMail userMail = new UserMail()
                {
                    MailId = mailId,
                    UserId = userId
                };

                this.userMailRepository.Add(userMail).Wait();
            }
        }
    }
}
