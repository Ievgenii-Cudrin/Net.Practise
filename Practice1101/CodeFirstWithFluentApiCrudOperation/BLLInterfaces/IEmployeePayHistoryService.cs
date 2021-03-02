using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IEmployeePayHistoryService
    {
        void CreateEmployeePayHistory(EmployeePayHistory item);

        List<EmployeePayHistory> GetDepartmentsByPredicate(Expression<Func<EmployeePayHistory, bool>> predicat);

        void UpdateEmployeePayHistory(EmployeePayHistory item);

        void DeleteEmployeePayHistory(int id);

        EmployeePayHistory GetEmployeePayHistory(int id);
    }
}
