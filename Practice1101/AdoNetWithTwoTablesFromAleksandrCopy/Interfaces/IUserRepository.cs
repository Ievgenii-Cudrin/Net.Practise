using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        
        User Get(int id);
        
        void Create(User item);
        
        void Update(User item);
        
        void Delete(int id);
    }
}
