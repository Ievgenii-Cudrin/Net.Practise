using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeeRepositoryRepository
    {
        public IEnumerable<Employee> GetAll();

        public Employee Get(int id);

        public void Create(Employee item);

        public void Update(Employee item);

        public void Delete(int id);
    }
}
