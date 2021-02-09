using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void EncryptData(string email)
        {
            User user = this.userService.GetAllUsers().Where(x => x.Email == email).FirstOrDefault();

            if(user != null)
            {
                user.Name = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Name));
                user.Surname = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Surname));
                user.Email = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Email));
                user.DateOfBirth = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.DateOfBirth));

                this.userService.UpdateUser(user);
            }
        }
    }
}
