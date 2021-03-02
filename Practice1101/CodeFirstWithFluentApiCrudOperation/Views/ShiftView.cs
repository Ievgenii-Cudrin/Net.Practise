using CodeFirstWithFluentApiCrudOperation.BLLInterfaces;
using CodeFirstWithFluentApiCrudOperation.DI;
using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.Views
{
    public static class ShiftView
    {
        static IShiftService shiftService = Startup.ConfigureService().GetRequiredService<IShiftService>();

        public static void CreateShift()
        {
            Shift shift = new Shift()
            {
                Name = "FirstShift",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            Shift shift2 = new Shift()
            {
                Name = "secondShift",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            shiftService.CreateShift(shift);
            shiftService.CreateShift(shift2);
            Console.WriteLine("Shift added");
        }

        public static void UpdateShift(int id)
        {
            Shift shift = shiftService.GetShift(id);

            shift.Name = "NewShift";
            shift.StartTime = DateTime.Now;
            shift.EndTime = DateTime.Now;

            shiftService.UpdateShift(shift);
            Console.WriteLine("Shift updated");
        }

        public static void DeleteShift(int id)
        {
            shiftService.DeleteShift(id);
            Console.WriteLine("Shift deleted");
        }
    }
}
