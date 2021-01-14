using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Services.PL.Commands;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();

        private ICommand addUsers;
        private ICommand listUsers;
        public CommandProcessor(ICommand addUsers, ICommand listUsers)
        {
            this.addUsers = addUsers;
            this.listUsers = listUsers;

            this.commands.Add(addUsers.Number, addUsers);
            this.commands.Add(listUsers.Number, listUsers);
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}