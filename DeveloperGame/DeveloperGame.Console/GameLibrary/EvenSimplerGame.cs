using System;

namespace DeveloperGame.ConsoleApp.GameLibrary
{
    class EvenSimplerGame : IGame
    {
        public void EndGame()
        {
            Console.WriteLine("Well done! Althought I'm not sure congraulations are really in order!");
        }

        public string GameDescription()
        {
            return "This is going to be really simple!";
        }

        public bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? Y/N");

            switch (Console.ReadLine().ToLower())
            {
                case "n":
                case "no":
                    return false;
                default:
                    return true;
            }
        }

        public void PlayGame()
        {
            do
            {
                Console.WriteLine("Type \"win\"");
            } while (Console.ReadLine() != "win");
        }

        public void SetupGame()
        {
            Console.WriteLine("To win the game type \"win\".");
        }
    }
}
