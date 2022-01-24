using System;

namespace DeveloperGame.Repositories.Models
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }
    }
}
