using GameLogic.Games;
using System;

namespace DeveloperGame.ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are about to play a game! I bet you're excited!");
            Console.WriteLine("By the way, what's your name?");
            var name = Console.ReadLine();
            Console.Clear();


            // Loop infinitely (the only way to exit the loop is to select the "Quit" menu option)
            while (true)
            {
                IGameLogic gameLogic = null;
                Console.Clear();
                Console.WriteLine($"Hello {name}! Which game do you want to play?");
                Console.WriteLine("1. Simple Number Guessing Game");
                Console.WriteLine("2. Even Simpler Game");
                Console.WriteLine("3. Rock Paper Scissors");
                Console.WriteLine("Quit");

                var option = Console.ReadLine().ToLower();

                if (option != string.Empty)
                {
                    switch (option[0])
                    {
                        case '1':
                            // This is an example of polymorphism - "gameLogic" is a "IGameLogic" type
                            // but we are assigning a "SimpleNumberGuessingGameLogic" object to it.
                            gameLogic = new SimpleNumberGuessingGameLogic();
                            break;
                        case '2':
                            gameLogic = new EvenSimplerGameLogic();
                            break;
                        case '3':
                            gameLogic = new RockPaperScissorsGameLogic();
                            break;
                        case 'q':
                            return;
                    }
                }

                var runner = new ConsoleGameService(gameLogic);
                runner.RunGame();
            }
        }
    }
}
