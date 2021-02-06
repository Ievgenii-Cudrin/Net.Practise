using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface ISalesPersonService
    {
        public void CreateSalesPerson(SalesPerson user);

        public List<SalesPerson> GetAllSalesPersons();

        public void UpdateSalesPerson(SalesPerson user);

        public void DeleteSalesPerson(int id);

        public SalesPerson GetSalesPerson(int id);
    }
}
