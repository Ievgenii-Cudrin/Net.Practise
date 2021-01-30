using System.Collections.Generic;

namespace TestingTask.Core.Models
{
    public class Group
    {
        public List<Guest> Guests { get; set; }

        public bool HasPets { get; set; }
    }
}