using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System.Collections.Generic;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleRepository
    {
        void Create(Role item);

        void Delete(Role id);

        Role Get(int id);

        List<Role> GetAllForOnePage(int skip);

        void Update(Role item);

    }
}
