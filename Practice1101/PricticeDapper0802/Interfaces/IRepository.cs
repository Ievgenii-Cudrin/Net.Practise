using PricticeDapper0802.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PricticeDapper0802.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T item);

        Task Update(T entity);

        Task Delete(T entity);

        Task<T> FindByID(int id);

        Task<T> GetEntityByString(string table, string email, string stringFoFind);

        Task<IEnumerable<T>> GetAll(Pager pager, string table);

        Task<int> GetCountInTable(string tableName);
    }
}
