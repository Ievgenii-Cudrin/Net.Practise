using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.Repository;
using AdoNetWithTwoTablesFromAleksandr0102.Services;
using AdoNetWithTwoTablesFromAleksandr0102.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.DI
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserView,UserView>()
                .AddTransient<IRoleView, RoleView>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
