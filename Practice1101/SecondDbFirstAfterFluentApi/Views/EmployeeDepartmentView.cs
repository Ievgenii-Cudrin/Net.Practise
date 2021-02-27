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
    public static class EmployeeDepartmentView
    {
        static IEmployeeDepartmenService employeeDepartmentService = Startup.ConfigureService().GetRequiredService<IEmployeeDepartmenService>();

        public static void CreateEmployeeDepartment()
        {
            EmployeeDepartmen employeeDep = new EmployeeDepartmen()
            {
                StartDateDocument = DateTime.Now,
                EndStateDocument = DateTime.Now,
                DepartmentId = 2,
                ShiftId = 2,
                BusinessEntityId = 6
            };

            EmployeeDepartmen employeeDep1 = new EmployeeDepartmen()
            {
                StartDateDocument = DateTime.Now,
                EndStateDocument = DateTime.Now,
                DepartmentId = 3,
                ShiftId = 3,
                BusinessEntityId = 5
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
                Console.WriteLine($"{employeeDep.BusinessEntityId}. {employeeDep.ShiftId}, {employeeDep.DepartmentId}, {employeeDep.StartDateDocument}, {employeeDep.EndStateDocument}");
            }
        }

        public static void DeleteEmployeeDepartment(int id)
        {
            employeeDepartmentService.DeleteEmployeeDepartmen(id);
            Console.WriteLine("Employee deleted");
        }
    }
}
