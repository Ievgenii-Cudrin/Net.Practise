using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System.Collections.Generic;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetAll();

        public Role Get(int id);

        public void Create(Role item);

        public void Update(Role item);

        public List<User> GetAllUserInRole(int roleId);

        public void Delete(int id);
    }
}
