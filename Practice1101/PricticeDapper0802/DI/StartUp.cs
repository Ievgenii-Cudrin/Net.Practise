using Microsoft.Extensions.DependencyInjection;
using PricticeDapper0802.Entities;
using PricticeDapper0802.Interfaces;
using PricticeDapper0802.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.DI
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IRepository<User>, Repository<User>>()
                .AddTransient<IRepository<Mail>, Repository<Mail>>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
