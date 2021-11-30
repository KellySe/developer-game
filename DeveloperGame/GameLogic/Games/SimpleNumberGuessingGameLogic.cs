using GameLogic.Models;
using System;

namespace GameLogic.Games
{
    public class SimpleNumberGuessingGameLogic : IGameLogic
    {
        // Storing all our globals in a class as it makes it easier to reset the game. i.e. "State = new SimpleNumberGuessingGameState();" rather than resetting each property individually.
        private SimpleNumberGuessingGameState State;

        // The value of this property depends on the value of the "GameComplete" property of "State"
        public bool GameComplete { get => State.GameComplete; set => State.GameComplete = value; }

        public SimpleNumberGuessingGameLogic()
        {
            Initialise();
        }

        public void Initialise()
        {
            State = new SimpleNumberGuessingGameState();
            GameComplete = false;
        }

        public string GetNextPrompt()
        {
            if (!State.GameStarted)
            {
                return $"I'm going to think of a number; you will have to guess what number I'm thinking of!{Environment.NewLine}Press enter to continue.";
            }

            if (!State.Configured)
            {
                return ConfigurationPrompt();
            }

            if (GameComplete)
            {
                return EndGameText();
            }

            return RoundPrompt();
        }

        public void HandlePlayerResponse(string entry)
        {
            // Not worried about the actualy input here 
            if (!State.GameStarted)
            {
                State.GameStarted = true;
                return;
            }

            if (!State.Configured)
            {
                Configure(entry);
                return;
            }

            PlayRound(entry);
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

            return $"{prompt}My number is between {State.RangeMinGuess} and {State.RangeMaxGuess}. You have {5 - State.Turns} guess(es) left." +
                $"{Environment.NewLine}What is your guess?";
        }

        public void PlayRound(string entry)
        {
            int.TryParse(entry, out var guess);
            State.FinalGuess = guess;

            if (guess != State.MysteryNumber)
            {
                // Shrink the range that contains the number based on previous guesses
                if (guess < State.MysteryNumber && guess > State.RangeMinGuess)
                {
                    State.RangeMinGuess = guess;
                }

                if (guess > State.MysteryNumber && guess < State.RangeMaxGuess)
                {
                    State.RangeMaxGuess = guess;
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
            string salutation;
            if (State.FinalGuess == State.MysteryNumber)
            {
                salutation = "Congatulations!";
            }
            else
            {
                salutation = "Bad Luck!";
            }

            return $"{salutation}{Environment.NewLine}My number was {State.MysteryNumber} and your last guess was {State.FinalGuess}.";
        }

        public void Configure(string entry)
        {
            if (State.MysteryNumber <= 0)
            {
                // if we can parse the entry into an integer and it is greater than zero
                // we consider the value to be valid and use it to set the mystery number
                if (int.TryParse(entry, out var max) && max > 0)
                {
                    State.MysteryNumber = new Random().Next(1, max);
                    State.RangeMinGuess = 0;
                    State.RangeMaxGuess = max;
                }

                // Ensure we don't attempt to configure multiple items in one go (only actually necessary in situation where we have multiple configuration steps)
                return;
            }
        }

        public string ConfigurationPrompt()
        {
            if (State.MysteryNumber <= 0)
            {
                return "Give me a max number to choose. The number must be greater than zero.";
            }

            // This function should not be run if mystery number is set appropriately.
            throw new InvalidOperationException("If the game is properly configured this line should not be hit.");
        }
    }
}
