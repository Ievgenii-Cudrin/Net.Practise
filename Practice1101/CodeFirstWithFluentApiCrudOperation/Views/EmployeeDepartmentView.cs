using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class EmployeeDepartmentView
    {
        static IEmployeeDepartmenService employeeDepartmentService = Startup.ConfigureService().GetRequiredService<IEmployeeDepartmenService>();

        public static void CreateEmployeeDepartment()
        {
            EmployeeDepartmen employeeDep = new EmployeeDepartmen()
            {
                StartDateDocument = DateTime.Now,
                EndStateDocument = DateTime.Now,
                DepartmentID = 2,
                ShiftID = 2,
                BusinessEntityID = 6
            };

            EmployeeDepartmen employeeDep1 = new EmployeeDepartmen()
            {
                StartDateDocument = DateTime.Now,
                EndStateDocument = DateTime.Now,
                DepartmentID = 3,
                ShiftID = 3,
                BusinessEntityID = 5
            };


            employeeDepartmentService.CreateEmployeeDepartmen(employeeDep);
            employeeDepartmentService.CreateEmployeeDepartmen(employeeDep1);
            Console.WriteLine("Employee added");
        }

        public static void UpdateEmployeeDepartment(int id)
        {
            EmployeeDepartmen employeeDep = employeeDepartmentService.GetEmployeeDepartmen(id);

            employeeDep.StartDateDocument = DateTime.Now;
            employeeDep.EndStateDocument = DateTime.Now;

            employeeDepartmentService.UpdateEmployeeDepartmen(employeeDep);
            Console.WriteLine("Employee updated");
        }

        public static void ShowAllEmployeesDepartment()
        {
            foreach (var employeeDep in employeeDepartmentService.GetAllEmployeeDepartmens().ToList())
            {
                Console.WriteLine($"{employeeDep.BusinessEntityID}. {employeeDep.ShiftID}, {employeeDep.DepartmentID}, {employeeDep.StartDateDocument}, {employeeDep.EndStateDocument}");
            }
        }

        public static void DeleteEmployeeDepartment(int id)
        {
            employeeDepartmentService.DeleteEmployeeDepartmen(id);
            Console.WriteLine("Employee deleted");
        }
    }
}
