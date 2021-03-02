using SomeBusinessService.Models;

namespace SomeBusinessService.Interfaces
{
    public interface IMainBusinessLogicService
    {
        void Create(Product product);

        void Delete(string name);

        Product Get(string name);

        void Update(Product product , string name);
    }
}
