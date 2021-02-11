using System;

namespace SomeBusinessService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Count { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
