using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();

        public User Get(int id);

        public void Create(User item);

        public void Update(User item);

        public void Delete(int id);
    }
}
