using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IShiftService
    {
        public void CreateShift(Shift item);

        public List<Shift> GetAllShifts();

        public void UpdateShift(Shift item);

        public void DeleteShift(int id);

        public Shift GetShift(int id);
    }
}
