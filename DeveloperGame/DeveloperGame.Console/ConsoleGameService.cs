using GameLogic.Games;
using System;

namespace DeveloperGame.ConsoleApp
{
    public class ConsoleGameService
    {
        private readonly IGameLogic gameLogic;

        public ConsoleGameService(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }

        public void RunGame()
        {
            Console.Clear();

            do {
                Play();
            } while(PlayAgain());
        }

        private void Play()
        {
            while(!gameLogic.GameComplete)
            {
                Console.Clear();
                Console.WriteLine(gameLogic.GetNextPrompt());
                gameLogic.HandlePlayerResponse(Console.ReadLine());
            }

            Console.Clear();
            Console.WriteLine(gameLogic.GetNextPrompt());
        }

        private bool PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to play again? Y/N");
            
            if(CheckPlayAgain(Console.ReadLine()))
            {
                gameLogic.Initialise();
                return true;
            }

            return false;
        }

        private bool CheckPlayAgain(string entry)
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
