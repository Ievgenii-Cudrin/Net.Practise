using CodeFirstWithFluentApiCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IDepartmentService
    {
        public void CreateDepartment(Department user);

        public List<Department> GetAllDepartments();

        public void UpdatePerson(Department user);

        public void DeleteDepartment(int id);

        public Department GetDepartment(int id);
    }
}
