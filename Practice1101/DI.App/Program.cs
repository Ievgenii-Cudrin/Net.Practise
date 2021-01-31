using DI.App.Abstractions;
using DI.App.Services.PL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI.App
{
    interface IRepository<T>
    {

    }

    internal class Program
    {
        private static void Main()
        {
            var container = Startup.ConfigureService();
            // Inversion of Control
            var manager = new CommandManager(container.GetRequiredService<ICommandProcessor>());

            manager.Start();
        }
    }
}
