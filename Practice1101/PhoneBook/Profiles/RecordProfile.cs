using AutoMapper;
using PhoneBook.Models;
using PhoneBook.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Profiles
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            this.CreateMap<Record, RecordViewModel>()
                .IncludeAllDerived();
            this.CreateMap<User, UserViewModel>();

            this.CreateMap<RecordViewModel, Record>()
                .IncludeAllDerived();
        }
    }
}
