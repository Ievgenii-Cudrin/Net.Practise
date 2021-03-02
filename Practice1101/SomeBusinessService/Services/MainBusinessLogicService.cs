using SomeBusinessService.Interfaces;
using System;
using SomeBusinessService.Models;

namespace SomeBusinessService.Services
{
    public class MainBusinessLogicService : IMainBusinessLogicService
    {
        private IDBManager _dBManager;
        public MainBusinessLogicService(IDBManager dBManager)
        {
            _dBManager = dBManager;
        }

        public void Create(Product product)
        {
            if (product != null && !string.IsNullOrEmpty(product.Name))
            {
                product.Id = Guid.NewGuid();
                product.LastUpdated = DateTime.Now;

                _dBManager.Create(product);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _dBManager.Delete(name);
            }
        }

        public Product Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _dBManager.Get(name);
            }

            throw new ArgumentNullException();
        }

        public void Update(Product product, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _dBManager.Update(product, name);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void UpdateSecond(Product product, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var updatedProduct = _dBManager.Get(name);
                if (updatedProduct.LastUpdated < DateTime.Now)
                {
                    _dBManager.Update(product, name);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
