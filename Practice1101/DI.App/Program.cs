using DI.App.Services.PL;
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
            // Inversion of Control
            var manager = new CommandManager();

            manager.Start();
        }
    }
}
