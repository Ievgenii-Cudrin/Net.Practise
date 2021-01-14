namespace DI.App.Abstractions
{
    public interface ICommand
    {
        int Number { get; }

        string DisplayName { get; }

        void Execute();
    }
}