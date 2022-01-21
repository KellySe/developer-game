using System;

namespace DeveloperGame.Repositories.Models
{
    public class Score
    {
        public Score()
        {
            Id = Guid.NewGuid();
        }

        internal Score(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// The ID of the game that this score is for.
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// The ID of the player who achieved this score
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The player's score
        /// </summary>
        public int ScoreValue { get; set; }
    }
}
