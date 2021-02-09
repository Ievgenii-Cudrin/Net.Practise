using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
