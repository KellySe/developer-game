using System;

namespace DeveloperGame.Repositories.Models
{
    public class PlayerAchievement
    {
        /// <summary>
        /// The ID of the achievement in the link relationship
        /// </summary>
        public Guid AchievementId { get; set; }

        /// <summary>
        /// The ID of the player in the link relationship
        /// </summary>
        public Guid PlayerId { get; set; }
    }
}
