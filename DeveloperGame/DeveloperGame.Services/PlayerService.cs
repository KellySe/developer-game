using DeveloperGame.Repositories;

namespace DeveloperGame.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IAchievementRepository achievementRepository;

        public PlayerService(IPlayerRepository playerRepository, IAchievementRepository achievementRepository)
        {
            this.playerRepository = playerRepository;
            this.achievementRepository = achievementRepository;
        }
    }
}
