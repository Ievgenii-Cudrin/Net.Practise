using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;
using TestingTask.Core.Services;

namespace TestingTask.Core.DependencyInjection
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IValidator<Group>, GroupValidator>()
                .AddTransient<IBookingService, BookingService>()
                 .BuildServiceProvider();

            return provider;
        }
    }
}
