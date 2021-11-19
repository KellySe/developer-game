using DeveloperGame.ConsoleApp.GameLibrary;
using System;

namespace DeveloperGame.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are about to play a game! I bet you're excited!");
            Console.WriteLine("By the way, what's your name?");
            var name = Console.ReadLine();
            Console.Clear();

            IGame game = null;

            while (game == null)
            {
                Console.Clear();
                Console.WriteLine($"Hello {name}! Which game do you want to play?");
                Console.WriteLine("1. Simple Number Guessing Game");
                Console.WriteLine("2. Even Simpler Game");
                Console.WriteLine("Quit");

                var option = Console.ReadLine().ToLower();

                if (option != string.Empty)
                {
                    switch (option[0])
                    {
                        case '1':
                            game = new SimpleNumberGuessingGame();
                            break;
                        case '2':
                            game = new EvenSimplerGame();
                            break;
                        case 'q':
                            return;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine(game.GameDescription());

            do {
                game.SetupGame();
                game.PlayGame();
                game.EndGame();
            } while (game.PlayAgain());
        }


    }
}
