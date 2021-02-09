using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricticeDapper0802.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task Add(T item);

        public Task Update(T entity);

        public Task Remove(T entity);

        public Task<T> FindByID(int id);

        public Task<IEnumerable<T>> FindAll();
    }
}
