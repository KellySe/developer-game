using GameLogic.Games;
using System;
using System.Collections.Generic;
using System.Text;

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
                Console.WriteLine(gameLogic.GetGameDescription());
                Console.WriteLine();
                ConfigureGame();
                Play();
                Console.Clear();
                Console.WriteLine(gameLogic.EndGameText());
            } while(CheckPlayAgain());
        }

        private void ConfigureGame()
        {
            foreach (var GameConfigurationItem in gameLogic.GetConfigurationItems())
            {
                while(!GameConfigurationItem.IsSet())
                {
                    Console.WriteLine(GameConfigurationItem.Prompt);
                    GameConfigurationItem.SetConfiguration(Console.ReadLine());
                    Console.Clear();
                }
            }
        }

        private void Play()
        {
            Console.Clear();

            while(!gameLogic.GameComplete)
            {
                Console.Clear();
                Console.WriteLine(gameLogic.RoundPrompt());
                gameLogic.PlayRound(Console.ReadLine());
            }
        }

        private bool CheckPlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine(gameLogic.PlayAgainPrompt());
            
            if(gameLogic.PlayAgainResult(Console.ReadLine()))
            {
                gameLogic.Reinitialise();
                return true;
            }

            return false;
        }
    }
}
