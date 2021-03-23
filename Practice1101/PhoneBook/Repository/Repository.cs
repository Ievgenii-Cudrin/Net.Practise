using Microsoft.EntityFrameworkCore;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly PhoneBookContext dbContext;

        public Repository(PhoneBookContext context)
        {
            this.dbContext = context;
        }

        public IList<T> GetAll()
        {
            return this.dbContext.Set<T>().ToList();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var result = this.dbContext.Set<T>();
            foreach (var include in includes)
            {
                result.Include(include);
            }

            return result.ToList();
        }

        public IList<T> Get(
            Expression<Func<T, bool>> predicat,
            params Expression<Func<T, object>>[] includes)
        {
            var result = this.dbContext.Set<T>();
            foreach (var include in includes)
            {
                result.Include(include);
            }

            return result.Where(predicat).ToList();
        }

        public IList<TResult> Get<TResult>(Expression<Func<T, TResult>> selector)
        {
            return this.dbContext.Set<T>()
                        .Select(selector).ToList();
        }

        public IList<T> Get(Expression<Func<T, bool>> predicat)
        {
            return this.dbContext.Set<T>()
                        .Where(predicat).ToList();
        }

        public IList<T> GetPage(int skip, int take)
        {
            return this.dbContext.Set<T>()
                        .Skip(skip).Take(take).ToList();
        }

        public IList<T> GetPageWithInclude(Expression<Func<T, object>> predicat,int skip, int take)
        {
            return this.dbContext.Set<T>()
                .Include(predicat).Skip(skip).Take(take).ToList();
        }

        public IList<T> GetPage(
            Expression<Func<T, bool>> predicat, int skip, int take)
        {
            return this.dbContext.Set<T>()
                        .Where(predicat)
                        .Skip(skip).Take(take).ToList();
        }

        public IList<TResult> Get<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicat)
        {
            return this.dbContext.Set<T>()
                        .Where(predicat)
                        .Select(selector).ToList();
        }

        public IList<TResult> Get<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicat,
            int skip, int take)
        {
            return this.dbContext.Set<T>()
                        .Where(predicat)
                        .Select(selector)
                        .Skip(skip).Take(take).ToList();
        }

        public bool Exist(Expression<Func<T, bool>> predicat)
        {
            return this.dbContext.Set<T>().Any(predicat);
        }

        public void Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            try
            {
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save()
        {
            try
            {

                this.dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Get(int id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            this.dbContext.Entry<T>(item).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = this.dbContext.Set<T>().Find(id);
            this.dbContext.Set<T>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        public IList<T> Except(IList<T> list, IEqualityComparer<T> comparer)
        {
            return this.dbContext.Set<T>().ToList().Except(list, comparer).ToList();
        }

        public T GetLastEntity<TOrderBy>(Expression<Func<T, TOrderBy>> orderBy)
        {
            return this.dbContext.Set<T>().OrderBy(orderBy).Last();
        }

        public int Count()
        {
            return this.dbContext.Set<T>().Count();
        }
    }
}
