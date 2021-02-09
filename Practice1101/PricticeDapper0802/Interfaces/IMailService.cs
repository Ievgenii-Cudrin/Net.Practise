using PricticeDapper0802.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Interfaces
{
    public interface IMailService
    {
        public void AddMail(Mail mail, int userId);

        public void UpdateMail(Mail mail);

        public List<Mail> GetAllMails();
    }
}
