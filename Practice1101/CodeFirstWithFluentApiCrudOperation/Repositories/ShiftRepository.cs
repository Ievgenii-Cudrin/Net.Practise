using CodeFirstWithFluentApiCrudOperation.DataContext;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        ApplicationContext db;

        public ShiftRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Shift item)
        {
            this.db.Shift.Add(item);
        }

        public void Delete(int id)
        {
            Shift item = db.Shift.FirstOrDefault();
            if (item != null)
            {
                this.db.Shift.Remove(item);
                this.db.SaveChanges();
            }
        }

        public Shift Get(int id)
        {
            return this.db.Shift.Find(id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return this.db.Shift.ToList();
        }

        public void Update(Shift item)
        {
            this.db.Update(item);
            this.db.SaveChanges();
        }
    }
}
