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
        List<Role> roles;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
            this.roles = this.roleRepository.GetAll().ToList();
        }

        public void CreateRole(Role role)
        {
            this.roleRepository.Create(role);
            this.roles.Add(role);
        }

        public void ShowAllRole()
        {
            foreach(var role in roles)
            {
                Console.WriteLine($"{role.Id}. {role.Name}");
            }
        }

        public List<Role> GetAllRoles()
        {
            return roles;
        }

        public void UpdateRole(Role role)
        {
            this.roleRepository.Update(role);
            this.roles.Where(x => x.Id == role.Id).Select(x => x = role);
        }

        public void DeleteRole(Role role)
        {
            this.roleRepository.Delete(role.Id);
            this.roles.Remove(role);
        }

        public Role GetRole(int id)
        {
            return this.roles.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
