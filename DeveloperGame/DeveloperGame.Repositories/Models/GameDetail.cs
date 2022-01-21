using System;

namespace DeveloperGame.Repositories.Models
{
    public class GameDetail
    {
        public GameDetail()
        {
            Id = Guid.NewGuid();
        }

        internal GameDetail(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the game
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the game
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date the game was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The game creator
        /// </summary>
        public string CreatedBy { get; set; }
    }
}
