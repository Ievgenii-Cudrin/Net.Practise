using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface ISalesPersonRepository
    {
        public IQueryable<SalesPerson> GetEmployeeByPredicate(Expression<Func<SalesPerson, bool>> predicat);

        public SalesPerson Get(int id);

        public void Create(SalesPerson item);

        public void Update(SalesPerson item);

        public void Delete(int id);
    }
}
