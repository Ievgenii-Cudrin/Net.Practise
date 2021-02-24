using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Entities;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Services
{
    public class EmployeeDepartmenService : IEmployeeDepartmenService
    {
        IEmployeeDepartmenRepository employeeDepartmenRepository;

        public EmployeeDepartmenService(IEmployeeDepartmenRepository employeeDepartmenRepository)
        {
            this.employeeDepartmenRepository = employeeDepartmenRepository;
        }
        public void CreateEmployeeDepartmen(EmployeeDepartmen item)
        {
            this.employeeDepartmenRepository.Create(item);
        }

        public void DeleteEmployeeDepartmen(int id)
        {
            this.employeeDepartmenRepository.Delete(id);
        }

        public List<EmployeeDepartmen> GetAllEmployeeDepartmens()
        {
            return this.employeeDepartmenRepository.GetAll().ToList();
        }

        public EmployeeDepartmen GetEmployeeDepartmen(int id)
        {
            return this.employeeDepartmenRepository.Get(id);
        }

        public void UpdateEmployeeDepartmen(EmployeeDepartmen item)
        {
            this.employeeDepartmenRepository.Update(item);
        }
    }
}
