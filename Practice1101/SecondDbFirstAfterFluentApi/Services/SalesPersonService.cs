using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<SalesPerson> GetAllSalesPersons()
        {
            return this.salesPersonRepository.GetAll().ToList();
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
