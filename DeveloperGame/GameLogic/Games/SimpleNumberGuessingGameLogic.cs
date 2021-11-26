using GameLogic.Games;
using GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.Games
{
    public class SimpleNumberGuessingGameLogic : IGameLogic
    {
        private SimpleNumberGuessingGameState State;

        public SimpleNumberGuessingGameLogic()
        {
            Reinitialise();
        }

        public bool GameComplete { get; set; }

        public void Reinitialise()
        {
            State = new SimpleNumberGuessingGameState();
            GameComplete = false;
        }

        public IEnumerable<GameConfigurationItem> GetConfigurationItems()
        {
            return new List<GameConfigurationItem>
            {
                new GameConfigurationItem
                {
                    Prompt = "Give me a max number to choose. The number must be greater than zero.",
                    SetConfiguration = entry => {
                        // if we can parse the entry into an integer and it is greater than zero
                        // we consider the value to be valid and use it to set the mystery number
                        if (int.TryParse(entry, out var max) && max > 0)
                        {
                            State.MysteryNumber = new Random().Next(1, max);
                            State.MinGuess = 0;
                            State.MaxGuess = max;
                        }
                    },
                    // Consider the setting to be set if it is greater than zero.
                    IsSet = () => State.MysteryNumber > 0
                }
            };
        }

        public string GetGameDescription()
        {
            return "I'm going to think of a number; you will have to guess what number I'm thinking of!";
        }

        public string RoundPrompt()
        {
            string prompt = string.Empty;

            if (State.FirstRound)
            {
                System.Threading.Thread.Sleep(500);
                prompt = $"OK I've picked a number.{Environment.NewLine}";
                State.FirstRound = false;
            }

            return $"{prompt}My number is between {State.MinGuess} and {State.MaxGuess}. You have {5 - State.Turns} guesses left." +
                $"{Environment.NewLine}What is your guess?";
        }

        public void PlayRound(string entry)
        {
            if(State.Turns > 5)
            {
                GameComplete = true;
                return;
            }

            int.TryParse(entry, out var guess);
            State.FinalGuess = guess;

            if (guess != State.MysteryNumber)
            {
                if (guess < State.MysteryNumber && guess > State.MinGuess)
                {
                    State.MinGuess = guess;
                }

                if (guess > State.MysteryNumber && guess < State.MaxGuess)
                {
                    State.MaxGuess = guess;
                }
            }
            else
            {
                GameComplete = true;
            }

            State.Turns++;

            if(State.Turns == 5)
            {
                GameComplete = true;
            }
        }

        public string EndGameText()
        {
            var salutation = string.Empty;

            if (State.FinalGuess == State.MysteryNumber)
            {
                salutation = "Congatulations!";
            }
            else
            {
                salutation = "Bad Luck!";
            }

            return$"{salutation}{Environment.NewLine}My number was {State.MysteryNumber} and your last guess was {State.FinalGuess}.";
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
