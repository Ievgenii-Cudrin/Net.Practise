using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Models;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.App
{
    public static class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<IUser, User>()
                .AddSingleton<IUserStore, UserStore>()
                .AddSingleton<IDatabaseService, InMemoryDatabaseService>()
                .AddSingleton<ICommand, AddUserCommand>()
                .AddSingleton<ICommand, ListUsersCommand>()
                .AddSingleton<ICommandProcessor, CommandProcessor>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
