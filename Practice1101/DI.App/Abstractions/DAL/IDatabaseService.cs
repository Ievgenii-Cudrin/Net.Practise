using System.Collections.Generic;

namespace DI.App.Abstractions
{
    public interface IDatabaseService
    {
        IEnumerable<T> Read<T>() where T : IDbEntity;

        void Write<T>(params T[] data) where T : IDbEntity;
    }
}