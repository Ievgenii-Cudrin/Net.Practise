using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface ISalesPersonService
    {
        public void CreateSalesPerson(SalesPerson item);

        public List<SalesPerson> GetAllSalesPersons();

        public void UpdateSalesPerson(SalesPerson item);

        public void DeleteSalesPerson(int id);

        public SalesPerson GetSalesPerson(int id);
    }
}
