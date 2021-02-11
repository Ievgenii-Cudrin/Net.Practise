using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System.Collections.Generic;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllForOnePage();

        Role Get(int id);

        void Create(Role item);

        void Update(Role item);

        void Delete(Role id);
    }
}
