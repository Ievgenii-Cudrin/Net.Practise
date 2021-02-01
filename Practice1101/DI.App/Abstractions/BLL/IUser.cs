namespace DI.App.Abstractions.BLL
{
    public interface IUser : IDbEntity
    {
        string Name { get; set; }
    }
}