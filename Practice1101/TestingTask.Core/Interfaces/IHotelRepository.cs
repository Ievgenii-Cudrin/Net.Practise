using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTask.Core.Models;

namespace TestingTask.Core.Interfaces
{
    public interface IHotelRepository
    {
        IQueryable<Hotel> GetHotels();
    }
}
