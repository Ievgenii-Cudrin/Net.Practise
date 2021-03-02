using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class SalesPersonService : ISalesPersonService
    {
        ISalesPersonRepository salesPersonRepository;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository)
        {
            this.salesPersonRepository = salesPersonRepository;
        }
        public void CreateSalesPerson(SalesPerson item)
        {
            this.salesPersonRepository.Create(item);
        }

        public void DeleteSalesPerson(int id)
        {
            this.salesPersonRepository.Delete(id);
        }

        public List<SalesPerson> GetAllSalesPersonsByPredicate(Expression<Func<SalesPerson, bool>> predicat)
        {
            return this.salesPersonRepository.GetEmployeeByPredicate(predicat).ToList();
        }

        public SalesPerson GetSalesPerson(int id)
        {
            return this.salesPersonRepository.Get(id);
        }

        public void UpdateSalesPerson(SalesPerson item)
        {
            this.salesPersonRepository.Update(item);
        }
    }
}
