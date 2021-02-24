using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Services;
using Microsoft.Extensions.DependencyInjection;
using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class EmployeeView
    {
        static IEmployeeService employeeService = Startup.ConfigureService().GetRequiredService<IEmployeeService>();

        public static void CreateEmployee()
        {
            Employee employee = new Employee()
            {
                JobTitle = "Title",
                NationalIdnumber = 11,
                OrganizationLevel = 51,
                PersonId = 5,
                LoginId = 1
            };

            Employee employee1 = new Employee()
            {
                JobTitle = "Title2",
                NationalIdnumber = 21,
                OrganizationLevel = 101,
                PersonId = 5,
                LoginId = 2
            };

            employeeService.CreateEmployee(employee);
            employeeService.CreateEmployee(employee1);
            Console.WriteLine("Employee added");
        }

        public static void UpdateEmployee(int id)
        {
            Employee employee = employeeService.GetEmployee(id);

            employee.JobTitle = "Title2New";
            employee.NationalIdnumber = 8;
            employee.OrganizationLevel = 100;

            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee updated");
        }

        public static void ShowAllEmployees()
        {
            foreach (var employee in employeeService.GetAllEmployees().ToList())
            {
                Console.WriteLine($"{employee.BusinessEntityId}. {employee.JobTitle}, {employee.NationalIdnumber}, {employee.OrganizationLevel}");
            }
        }

        public static void DeleteEmployee(int id)
        {
            employeeService.DeleteEmployee(id);
            Console.WriteLine("Employee deleted");
        }
    }
}
