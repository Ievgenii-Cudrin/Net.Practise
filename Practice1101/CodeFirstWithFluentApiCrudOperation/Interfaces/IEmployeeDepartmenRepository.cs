using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeeDepartmenRepository
    {
        public IEnumerable<EmployeeDepartmen> GetAll();

        public EmployeeDepartmen Get(int id);

        public void Create(EmployeeDepartmen item);

        public void Update(EmployeeDepartmen item);

        public void Delete(int id);
    }
}
