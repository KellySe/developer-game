using System;

namespace DeveloperGame.Repositories.Models
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
        }

        internal Player(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }
    }
}
