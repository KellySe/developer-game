using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.Models
{
    public class SimpleNumberGuessingGameState
    {
        public SimpleNumberGuessingGameState()
        {
            FirstRound = true;
        }

        /// <summary>
        /// Will return true if the game is fully configured.
        /// </summary>
        public bool Configured => MysteryNumber > 0; // The MysteryNumber must be greater than zero to consider the game configured.
        public bool GameComplete { get; set; }
        public int FinalGuess { get; set; }
        public int MysteryNumber { get; set; }
        public int RangeMinGuess { get; set; }
        public int RangeMaxGuess { get; set; }
        public bool FirstRound { get; set; }
        public int Turns { get; set; }
        public bool GameStarted { get; set; }
    }
}
