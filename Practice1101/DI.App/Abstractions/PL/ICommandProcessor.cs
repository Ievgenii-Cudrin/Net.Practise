using System.Collections.Generic;

namespace DI.App.Abstractions
{
    public interface ICommandProcessor
    {
        void Process(int command);

        IEnumerable<ICommand> Commands { get; }
    }
}