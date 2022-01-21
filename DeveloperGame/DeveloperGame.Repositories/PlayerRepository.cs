using DeveloperGame.Repositories.Datasources;

namespace DeveloperGame.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDeveloperGameDb developerGameDb;

        public PlayerRepository(IDeveloperGameDb developerGameDb)
        {
            this.developerGameDb = developerGameDb;
        }
    }
}
