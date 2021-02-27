using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeePayHistoryService
    {
        public void CreateEmployeePayHistory(EmployeePayHistory item);

        public List<EmployeePayHistory> GetAllDepartments();

        public void UpdateEmployeePayHistory(EmployeePayHistory item);

        public void DeleteEmployeePayHistory(int id);

        public EmployeePayHistory GetEmployeePayHistory(int id);
    }
}
