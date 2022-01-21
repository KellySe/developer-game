using DeveloperGame.Repositories;

namespace DeveloperGame.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IAchievementRepository achievementRepository;

        public GameService(IGameRepository gameRepository, IAchievementRepository achievementRepository)
        {
            this.gameRepository = gameRepository;
            this.achievementRepository = achievementRepository;
        }
    }
}
