using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IShiftRepository
    {
        public IQueryable<Shift> GetEmployeeByPredicate(Expression<Func<Shift, bool>> predicat);

        public Shift Get(int id);

        public void Create(Shift item);

        public void Update(Shift item);

        public void Delete(int id);
    }
}
