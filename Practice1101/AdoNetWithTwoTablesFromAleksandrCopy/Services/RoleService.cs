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
        IUserRepository userRepository;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepo)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepo;
        }

        public void CreateRole(Role role)
        {
            this.roleRepository.Create(role);
        }

        public void UpdateRole(Role role)
        {
            this.roleRepository.Update(role);
            this.userRepository.UpdateRoleInUsersCache(role);
        }

        public void DeleteRole(Role role)
        {
            this.roleRepository.Delete(role);
        }

        public Role GetRole(int id)
        {
            return this.roleRepository.Get(id);
        }
    }
}
