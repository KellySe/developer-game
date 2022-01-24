using DeveloperGame.Repositories.Models;
using System.Collections.Generic;

namespace DeveloperGame.Repositories.Datasources
{
    public interface IDeveloperGameDb
    {
        List<GameDetail> GameDetails { get; set; }
        List<Score> Scores { get; set; }
        List<Player> Players { get; set; }
        List<Achievement> Achievements { get; set; }
        List<PlayerAchievement> PlayerAchievements { get; set; }

        void SaveChanges();
    }
}