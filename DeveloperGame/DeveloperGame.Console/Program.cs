using System;

namespace DeveloperGame.ConsoleApp
{
    class Program
    {
        private static int MyNumber { get; set; }
        private static int MinGuess { get; set; }
        private static int MaxGuess { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("You are about to play a game! I bet you're excited!");
            Console.WriteLine("By the way, what's your name?");
            var name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello {name}! I'm going to think of a number; you will have to guess what number I'm thinking of!");

            do {
                SetupGame();
                var finalGuess = PlayGame();
                EndGame(finalGuess);
            } while (PlayAgain());
        }

        private static void SetupGame()
        {
            int max;
            Console.WriteLine("Give me a max number to choose.");

            while (!int.TryParse(Console.ReadLine(), out max) || max == 0)
            {
                Console.WriteLine("You must enter a number greater than zero!");
            }

            MyNumber = new Random().Next(1, max);
            MaxGuess = max;
        }

        private static int PlayGame()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("OK I've picked a number.");

            int guess = 0;

            for (int turn = 0; turn < 5 && guess != MyNumber; turn++)
            {
                Console.WriteLine($"My number is between {MinGuess} and {MaxGuess}. What is your guess?");
                int.TryParse(Console.ReadLine(), out guess);

                if(guess != MyNumber)
                {
                    if(guess < MyNumber && guess > MinGuess)
                    {
                        MinGuess = guess;
                    }

                    if (guess > MyNumber && guess < MaxGuess)
                    {
                        MaxGuess = guess;
                    }
                }
            }

            return guess;
        }

        private static void EndGame(int guess)
        {
            if (guess == MyNumber)
            {
                Console.WriteLine("Congatulations!");
            }
            else
            {
                Console.WriteLine("Bad Luck!");
            }

            Console.WriteLine($"My number was {MyNumber} and your guess was {guess}.");
            Console.WriteLine("Do you want to play again? Y/N");
        }

        private static bool PlayAgain()
        {
            switch (Console.ReadLine().ToLower())
            {
                case "n":
                case "no":
                    return false;
                    break;
                default:
                    return true;
                    break;
            }
        }
    }
}
