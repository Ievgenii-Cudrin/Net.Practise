using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandr0102.Repository;
using AdoNetWithTwoTablesFromAleksandr0102.Services;
using AdoNetWithTwoTablesFromAleksandr0102.Views;
using AdoNetWithTwoTablesFromAleksandrCopy.Helpers;
using AdoNetWithTwoTablesFromAleksandrCopy.Interfaces;
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
                .AddTransient<IUserRepository>(s => new UserRepository("UserDBConnection"))
                .AddTransient<IRoleRepository>(s => new RoleRepository("UserDBConnection"))
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserView,UserView>()
                .AddTransient<IRoleView, RoleView>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
