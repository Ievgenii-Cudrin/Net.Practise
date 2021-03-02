using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IShiftService
    {
        void CreateShift(Shift item);

        List<Shift> GetAllShiftsByPredicate(Expression<Func<Shift, bool>> predicat);

        void UpdateShift(Shift item);

        void DeleteShift(int id);

        Shift GetShift(int id);
    }
}
