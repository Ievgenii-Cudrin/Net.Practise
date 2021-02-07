using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IDepartmentReposotiry
    {
        public IEnumerable<Department> GetAll();

        public Department Get(int id);

        public void Create(Department item);

        public void Update(Department item);

        public void Delete(int id);
    }
}
