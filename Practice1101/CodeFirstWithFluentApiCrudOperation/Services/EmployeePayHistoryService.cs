using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class EmployeePayHistoryService : IEmployeePayHistoryService
    {
        IEmployeePayHistoryRepository employeePayHistoryRepository;

        public EmployeePayHistoryService(IEmployeePayHistoryRepository employeePayHistoryRepository)
        {
            this.employeePayHistoryRepository = employeePayHistoryRepository;
        }
        public void CreateEmployeePayHistory(EmployeePayHistory item)
        {
            this.employeePayHistoryRepository.Create(item);
        }

        public void DeleteEmployeePayHistory(int id)
        {
            this.employeePayHistoryRepository.Delete(id);
        }

        public List<EmployeePayHistory> GetDepartmentsByPredicate(Expression<Func<EmployeePayHistory, bool>> predicat)
        {
            return this.employeePayHistoryRepository.GetEmployeeByPredicate(predicat).ToList();
        }

        public EmployeePayHistory GetEmployeePayHistory(int id)
        {
            return this.employeePayHistoryRepository.Get(id);
        }

        public void UpdateEmployeePayHistory(EmployeePayHistory item)
        {
            this.employeePayHistoryRepository.Update(item);
        }
    }
}
