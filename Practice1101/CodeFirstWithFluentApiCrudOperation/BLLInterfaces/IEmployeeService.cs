using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeeService
    {
        public void CreateEmployee(Employee item);

        public List<Employee> GetAllEmployees();

        public void UpdateEmployee(Employee item);

        public void DeleteEmployee(int id);

        public Employee GetEmployee(int id);
    }
}
