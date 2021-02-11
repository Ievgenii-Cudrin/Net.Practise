using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void CreateRole(Role role)
        {
            this.roleRepository.Create(role);
        }

        public void UpdateRole(Role role)
        {
            this.roleRepository.Update(role);
        }

        public void DeleteRole(Role role)
        {
            this.roleRepository.Delete(role.Id);
        }

        public Role GetRole(int id)
        {
            return this.roleRepository.Get(id);
        }
    }
}
