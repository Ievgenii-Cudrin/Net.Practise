using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IShiftRepository
    {
        public IEnumerable<Shift> GetAll();

        public Shift Get(int id);

        public void Create(Shift item);

        public void Update(Shift item);

        public void Delete(int id);
    }
}
