using System;

namespace DeveloperGame.Repositories.Models
{
    public class Achievement
    {
        public Achievement()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the game that this achievemnet is linked to.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The name of the achievement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The achievement desctiption.
        /// </summary>
        public string Description { get; set; }
    }
}
