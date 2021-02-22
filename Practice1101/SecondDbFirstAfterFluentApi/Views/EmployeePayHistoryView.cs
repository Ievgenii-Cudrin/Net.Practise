using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using Microsoft.Extensions.DependencyInjection;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class EmployeePayHistoryView
    {
        static IEmployeePayHistoryService employeePayHistoryService = Startup.ConfigureService().GetRequiredService<IEmployeePayHistoryService>();

        public static void CreateEmployeePayHistory()
        {
            EmployeePayHistory employeePayHistory = new EmployeePayHistory()
            {
                BusinessEntityId = 5,
                PayFrequency = 10,
                Rate = 1,
                RateChangeDate = DateTime.Now
            };

            EmployeePayHistory employeePayHistory1 = new EmployeePayHistory()
            {
                BusinessEntityId = 6,
                PayFrequency = 20,
                Rate = 2,
                RateChangeDate = DateTime.Now
            };

            employeePayHistoryService.CreateEmployeePayHistory(employeePayHistory);
            employeePayHistoryService.CreateEmployeePayHistory(employeePayHistory1);
            Console.WriteLine("EmployeePayHistory added");
        }

        public static void UpdateEmployeePayHistory(int id)
        {
            EmployeePayHistory employeePayHistory = employeePayHistoryService.GetEmployeePayHistory(id);

            employeePayHistory.PayFrequency = 200;
            employeePayHistory.Rate = 10;
            employeePayHistory.RateChangeDate = DateTime.Now;

            employeePayHistoryService.UpdateEmployeePayHistory(employeePayHistory);
            Console.WriteLine("EmployeePayHistory updated");
        }

        public static void ShowAllEmployeePayHistories()
        {
            foreach (var employeePayHistory in employeePayHistoryService.GetAllDepartments().ToList())
            {
                Console.WriteLine($"{employeePayHistory.EmployeePayHistoryId}. {employeePayHistory.PayFrequency}, {employeePayHistory.Rate}, {employeePayHistory.RateChangeDate}");
            }
        }

        public static void DeleteEmployeePayHistory(int id)
        {
            employeePayHistoryService.DeleteEmployeePayHistory(id);
            Console.WriteLine("EmployeePayHistory deleted");
        }
    }
}
