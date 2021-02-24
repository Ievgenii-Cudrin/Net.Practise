using SecondDbFirstAfterFluentApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Interfaces
{
    public interface IEmployeePayHistoryRepository
    {
        public IEnumerable<EmployeePayHistory> GetAll();

        public EmployeePayHistory Get(int id);

        public void Create(EmployeePayHistory item);

        public void Update(EmployeePayHistory item);

        public void Delete(int id);
    }
}
