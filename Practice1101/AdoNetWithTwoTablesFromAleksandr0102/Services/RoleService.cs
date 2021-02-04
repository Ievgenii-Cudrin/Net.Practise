using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Services
{
    public class RoleService
    {
        IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void CreateRole(Role role)
        {
            roleRepository.Create(role);
        }

        public void ShowAllRole()
        {
            foreach(var role in roleRepository.GetAll().ToList())
            {
                Console.WriteLine($"{role.Id}. {role.Name}");
            }
        }

        public List<Role> GetAllRoles()
        {
            return roleRepository.GetAll().ToList();
        }

        public void UpdateRole(Role role)
        {
            roleRepository.Update(role);
        }

        public void DeleteRole(int id)
        {
            roleRepository.Delete(id);
        }
    }
}
