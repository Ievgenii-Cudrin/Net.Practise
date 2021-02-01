using DI.App.Abstractions.BLL;

namespace DI.App.Models
{
    public class User : IUser
    {
        public int Id { get; internal set; }

        public string Name { get; set; }
    }
}