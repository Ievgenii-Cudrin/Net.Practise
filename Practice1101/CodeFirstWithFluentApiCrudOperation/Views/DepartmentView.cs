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
    public static class DepartmentView
    {
        static IDepartmentService departmentService = Startup.ConfigureService().GetRequiredService<IDepartmentService>();

        public static void CreateDepartment()
        {
            Department department = new Department()
            {
                GroupName = "IT",
                Name = "Programing"
            };

            Department department1 = new Department()
            {
                GroupName = "IT",
                Name = "Programing1"
            };

            departmentService.CreateDepartment(department);
            departmentService.CreateDepartment(department1);
            Console.WriteLine("Department added");
        }

        public static void UpdateDepartment(int id)
        {
            Department department = departmentService.GetDepartment(id);

            department.Name = "NewPrograming";
            department.GroupName = "NewIt";

            departmentService.UpdateDepartment(department);
            Console.WriteLine("Department updated");
        }

        public static void DeleteDepartment(int id)
        {
            departmentService.DeleteDepartment(id);
            Console.WriteLine("Department deleted");
        }
    }
}
