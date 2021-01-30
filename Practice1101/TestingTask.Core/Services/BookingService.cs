using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core.Services
{
    public class BookingService : IBookingService
    {
        IValidator<Group> validator;
        IHotelRepository hotelRepository;

        public BookingService(IValidator<Group> validator, IHotelRepository hotelRepository)
        {
            this.validator = validator;
            this.hotelRepository = hotelRepository;
        }

        public List<Room> Book(string hotelName, Group group)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSuitableHotelNames(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
