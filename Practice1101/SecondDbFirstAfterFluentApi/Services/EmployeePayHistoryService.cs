﻿using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.Interfaces;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<EmployeePayHistory> GetAllDepartments()
        {
            return this.employeePayHistoryRepository.GetAll().ToList();
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
