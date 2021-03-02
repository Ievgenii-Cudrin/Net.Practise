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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void CreateEmployee(Employee item)
        {
            this.employeeRepository.Create(item);
        }

        public void DeleteEmployee(int id)
        {
            this.employeeRepository.Delete(id);
        }

        public List<Employee> GetAllEmployeesByPredicate(Expression<Func<Employee, bool>> predicat)
        {
            return this.employeeRepository.GetEmployeeByPredicate(predicat).ToList();
        }

        public Employee GetEmployee(int id)
        {
            return this.employeeRepository.Get(id);
        }

        public void UpdateEmployee(Employee item)
        {
            this.employeeRepository.Update(item);
        }
    }
}
