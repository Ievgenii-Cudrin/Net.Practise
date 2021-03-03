using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();

        T Get(int id);

        void Add(T item);

        void Update(T item);

        void Delete(int id);

        IList<T> GetAll(params Expression<Func<T, object>>[] includes);

        void Save();

        bool Exist(Expression<Func<T, bool>> predicat);

        IList<T> GetPage(
            Expression<Func<T, bool>> predicat,
            PageInfo page);

        IList<T> GetPage(PageInfo page);

        IList<TResult> Get<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicat);

        public IList<TResult> Get<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicat,
            PageInfo page);

        IList<TResult> Get<TResult>(Expression<Func<T, TResult>> selector);

        IList<T> Get(Expression<Func<T, bool>> predicat);

        IList<T> Except(IList<T> list, IEqualityComparer<T> comparer);

        T GetLastEntity<TOrderBy>(Expression<Func<T, TOrderBy>> orderBy);
    }
}
