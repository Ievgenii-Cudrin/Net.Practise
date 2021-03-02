using PricticeDapper0802.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Interfaces
{
    public interface IMailService
    {
        void AddMail(Mail mail, int userId);

        void UpdateMail(Mail mail);

        void DeleteMail(int id);

        int GetCountOfEmailTableRows();

        List<Mail> GetAllMailsInPage(Pager pager, string tableName);
    }
}
