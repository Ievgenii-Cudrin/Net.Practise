using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeeDepartmenService
    {
        public void CreateEmployeeDepartmen(EmployeeDepartmen user);

        public List<EmployeeDepartmen> GetAllEmployeeDepartmens();

        public void UpdateEmployeeDepartmen(EmployeeDepartmen user);

        public void DeleteEmployeeDepartmen(int id);

        public EmployeeDepartmen GetEmployeeDepartmen(int id);
    }
}
