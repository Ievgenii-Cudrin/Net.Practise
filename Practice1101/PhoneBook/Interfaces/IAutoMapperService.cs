using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IAutoMapperService
    {
        TDomain CreateMapFromVMToDomain<TView, TDomain>(TView viewModelType);

        List<TRecordView> CreateListMapFromDomainToVMWithIncludeType
            <TRecordDomain, TRecordView, TUserDomain, TUserViewModel, TStatusDomain, TStatusView>(List<TRecordDomain> viewModelType);

        TRecordView CreateMapFromVMToDomainWithIncludeLsitType
            <TRecordDomain, TRecordView, TStatusDomain, TStatusView>(TRecordDomain viewModelType);
    }
}
