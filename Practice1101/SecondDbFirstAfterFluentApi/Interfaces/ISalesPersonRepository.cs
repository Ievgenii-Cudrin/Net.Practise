using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface ISalesPersonRepository
    {
        public IEnumerable<SalesPerson> GetAll();

        public SalesPerson Get(int id);

        public void Create(SalesPerson item);

        public void Update(SalesPerson item);

        public void Delete(int id);
    }
}
