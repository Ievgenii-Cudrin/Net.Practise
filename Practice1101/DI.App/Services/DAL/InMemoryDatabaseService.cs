using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;

namespace DI.App.Services
{
    public class InMemoryDatabaseService : IDatabaseService
    {
        private readonly Dictionary<int, IDbEntity> inMemoryDatabase = new Dictionary<int, IDbEntity>();

        public IEnumerable<T> Read<T>() 
            where T : IDbEntity
        {
            return this.inMemoryDatabase.Values
                .Where(v => v is T)
                .Cast<T>()
                .AsEnumerable();
        }

        public void Write<T>(params T[] data)
            where T : IDbEntity
        {
            foreach (var entity in data)
            {
                this.inMemoryDatabase.TryAdd(entity.Id, entity);
            }
        }
    }
}