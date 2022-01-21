using System;

namespace GameLogic.Games
{
    public class EvenSimplerGameLogic : IGameLogic
    {
        public EvenSimplerGameLogic()
        {
            Initialise();
        }

        public bool GameComplete { get; set; }
        private bool GameStarted;

        public void Initialise()
        {
            GameComplete = false;
            GameStarted = false;
        }

        public string GetNextPrompt()
        {
            string prompt;

            // Game hasn't started - display game introduction
            if (!GameStarted)
            {
                prompt = $"This is going to be really simple!{Environment.NewLine}Press enter to play!";
            }
            // Game is over - congratulate player
            else if (GameComplete)
            {
                prompt = "Well done! Although I'm not sure congraulations are really in order!";
            }
            // Standard game prompt.
            else
            {
                prompt = "Type \"win\"";
            }

            return prompt;
        }

        public void HandlePlayerResponse(string entry)
        {
            if (!GameStarted)
            {
                GameStarted = true;
                return;
            }

            // If the user entered "win" the game is complete.
            GameComplete = string.Equals(entry, "win", StringComparison.OrdinalIgnoreCase);
        }


    }
}