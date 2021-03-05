using AutoMapper;
using PhoneBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class AutoMapperService : IAutoMapperService
    {
        public TDomain CreateMapFromVMToDomain<TView, TDomain>(TView viewModelType)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TView, TDomain>());
            var mapper = new Mapper(config);
            var domainAfterMapping = mapper.Map<TView, TDomain>(viewModelType);

            return domainAfterMapping;
        }

        public List<TRecordView> CreateListMapFromDomainToVMWithIncludeType
            <TRecordDomain, TRecordView, TUserDomain, TUserViewModel, TStatusDomain, TStatusView>(List<TRecordDomain> viewModelType)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TRecordDomain, TRecordView>();
                cfg.CreateMap<TStatusDomain, TStatusView>();
                cfg.CreateMap<TUserDomain, TUserViewModel>();
            });
            var mapper = new Mapper(configuration);
            var domainAfterMapping = mapper.Map<List<TRecordDomain>, List<TRecordView>>(viewModelType);

            return domainAfterMapping;
        }

        public TRecordView CreateMapFromVMToDomainWithIncludeLsitType
            <TRecordDomain, TRecordView, TStatusDomain, TStatusView>(TRecordDomain viewModelType)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TRecordDomain, TRecordView>();
                cfg.CreateMap<TStatusDomain, TStatusView>();
            });
            var mapper = new Mapper(configuration);
            var domainAfterMapping = mapper.Map<TRecordDomain, TRecordView>(viewModelType);

            return domainAfterMapping;
        }
    }
}
