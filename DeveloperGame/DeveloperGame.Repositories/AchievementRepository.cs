using DeveloperGame.Repositories.Datasources;

namespace DeveloperGame.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly IDeveloperGameDb developerGameDb;

        public AchievementRepository(IDeveloperGameDb developerGameDb)
        {
            this.developerGameDb = developerGameDb;
        }
    }
}
