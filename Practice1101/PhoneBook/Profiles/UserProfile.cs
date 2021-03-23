using AutoMapper;
using PhoneBook.Models;
using PhoneBook.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserViewModel>();
            this.CreateMap<UserViewModel, User>();
        }
    }
}
