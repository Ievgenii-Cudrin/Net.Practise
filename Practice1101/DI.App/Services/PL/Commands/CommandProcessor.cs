using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Services.PL.Commands;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();

        private IEnumerable<ICommand> typesRealization;
            
        public CommandProcessor(IEnumerable<ICommand> typesRealization)
        {
            this.typesRealization = typesRealization;

            foreach(var type in typesRealization)
            {
                this.commands.Add(type.Number, type);
            }
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}