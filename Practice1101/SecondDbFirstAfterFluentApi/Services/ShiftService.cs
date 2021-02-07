using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class ShiftService : IShiftService
    {
        IShiftRepository shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void CreateShift(Shift item)
        {
            this.shiftRepository.Create(item);
        }

        public void DeleteShift(int id)
        {
            this.shiftRepository.Delete(id);
        }

        public List<Shift> GetAllShifts()
        {
            return this.shiftRepository.GetAll().ToList();
        }

        public Shift GetShift(int id)
        {
            return this.shiftRepository.Get(id);
        }

        public void UpdateShift(Shift item)
        {
            this.shiftRepository.Update(item);
        }
    }
}
