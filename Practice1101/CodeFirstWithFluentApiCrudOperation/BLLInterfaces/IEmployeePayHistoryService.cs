using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeePayHistoryService
    {
        public void CreateEmployeePayHistory(EmployeePayHistory user);

        public List<EmployeePayHistory> GetAllDepartments();

        public void UpdateEmployeePayHistory(EmployeePayHistory user);

        public void DeleteEmployeePayHistory(int id);

        public EmployeePayHistory GetEmployeePayHistory(int id);
    }
}
