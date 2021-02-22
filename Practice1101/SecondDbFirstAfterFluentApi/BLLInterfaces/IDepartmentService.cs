using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.BLLInterfaces
{
    public interface IDepartmentService
    {
        public void CreateDepartment(Department item);

        public List<Department> GetAllDepartments();

        public void UpdateDepartment(Department item);

        public void DeleteDepartment(int id);

        public Department GetDepartment(int id);
    }
}
