using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;

namespace DI.App.Services
{
    public class UserStore : IUserStore
    {
        private readonly IDatabaseService dbService = new InMemoryDatabaseService();

        public IEnumerable<IUser> Users => this.dbService.Read<IUser>();

        public void AddUser(IUser user)
        {
            this.dbService.Write(user);
        }

        public IUser FindUser(string name)
        {
            return this.dbService.Read<IUser>()
                .FirstOrDefault(user => user.Name == name);
        }

        public IUser FindUser(int id)
        {
            return this.dbService.Read<IUser>()
                .FirstOrDefault(user => user.Id == id);
        }
    }
}