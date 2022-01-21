using DeveloperGame.Repositories.Datasources;

namespace DeveloperGame.Repositories
{
    public class GameRepository: IGameRepository
    {
        private readonly IDeveloperGameDb developerGameDb;

        public GameRepository(IDeveloperGameDb developerGameDb)
        {
            this.developerGameDb = developerGameDb;
        }
    }
}
