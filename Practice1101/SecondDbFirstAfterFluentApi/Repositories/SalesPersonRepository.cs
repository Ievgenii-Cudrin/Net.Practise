using CodeFirstWithFluentApiCrudOperation.Interfaces;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        EfCodeFirstWithFluentApiContext db = new EfCodeFirstWithFluentApiContext();
        public void Create(SalesPerson item)
        {
            this.db.SalesPerson.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            SalesPerson item = db.SalesPerson.FirstOrDefault();
            if (item != null)
            {
                this.db.SalesPerson.Remove(item);
                this.db.SaveChanges();
            }
        }

        public SalesPerson Get(int id)
        {
            return this.db.SalesPerson.Find(id);
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return this.db.SalesPerson.ToList();
        }

        public void Update(SalesPerson item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
