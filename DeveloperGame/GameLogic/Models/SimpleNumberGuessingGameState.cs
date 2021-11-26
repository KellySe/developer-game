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

        public int FinalGuess { get; set; }
        public int MysteryNumber { get; set; }
        public int MinGuess { get; set; }
        public int MaxGuess { get; set; }
        public bool FirstRound { get; set; }
        public int Turns { get; set; }
    }
}
