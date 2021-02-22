using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeeDepartmenService
    {
        public void CreateEmployeeDepartmen(EmployeeDepartmen item);

        public List<EmployeeDepartmen> GetAllEmployeeDepartmens();

        public void UpdateEmployeeDepartmen(EmployeeDepartmen item);

        public void DeleteEmployeeDepartmen(int id);

        public EmployeeDepartmen GetEmployeeDepartmen(int id);
    }
}
