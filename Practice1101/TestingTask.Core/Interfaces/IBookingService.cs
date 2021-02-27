using System.Collections.Generic;
using TestingTask.Core.Models;

namespace TestingTask.Core.Interfaces
{
    public interface IBookingService
    {
        List<string> GetSuitableHotelNames(Group group);

        List<Room> Book(string hotelName, Group group);
    }
}