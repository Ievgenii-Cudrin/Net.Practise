using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll();

        public Employee Get(int id);

        public void Create(Employee item);

        public void Update(Employee item);

        public void Delete(int id);
    }
}
