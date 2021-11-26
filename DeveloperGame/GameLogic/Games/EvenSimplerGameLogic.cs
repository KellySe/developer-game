using GameLogic.Models;
using System;
using System.Collections.Generic;

namespace GameLogic.Games
{
    public class EvenSimplerGameLogic : IGameLogic
    {
        public EvenSimplerGameLogic()
        {
            Reinitialise();
        }

        public bool GameComplete { get; set; }

        public void Reinitialise()
        {
            GameComplete = false;
        }

        public string GetGameDescription()
        {
            return "This is going to be really simple!";
        }

        public IEnumerable<GameConfigurationItem> GetConfigurationItems()
        {
            // This game needs no configuration so we return an empty list.
            return new List<GameConfigurationItem>();
        }

        public string RoundPrompt()
        {
            return "Type \"win\"";
        }

        public void PlayRound(string entry)
        {
            // If the user entered "win" the game is complete.
            GameComplete = string.Equals(entry, "win", StringComparison.OrdinalIgnoreCase);
        }

        public string EndGameText()
        {
            return "Well done! Although I'm not sure congraulations are really in order!";
        }

        public string PlayAgainPrompt()
        {
            return "Do you want to play again? Y/N";
        }

        public bool PlayAgainResult(string entry)
        {
            switch (entry.ToLower())
            {
                case "n":
                case "no":
                    return false;
                default:
                    return true;
            }
        }
    }
}