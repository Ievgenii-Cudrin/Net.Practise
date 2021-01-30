using TestingTask.Core.Models;

namespace TestingTask.Core.Interfaces
{
    public interface IValidator<T>
    {
        bool Validate(T item);
    }
}