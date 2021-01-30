using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;
using TestingTask.Core.Services;

namespace TestingTask.Core.Test.DI
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
