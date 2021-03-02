using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface ISalesPersonService
    {
        public void CreateSalesPerson(SalesPerson item);

        public List<SalesPerson> GetAllSalesPersonsByPredicate(Expression<Func<SalesPerson, bool>> predicat);

        public void UpdateSalesPerson(SalesPerson item);

        public void DeleteSalesPerson(int id);

        public SalesPerson GetSalesPerson(int id);
    }
}
