using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperGame.ConsoleApp.GameLibrary
{
    interface IGame
    {
        string GameDescription();
        /// <summary>
        /// Sets the game up
        /// </summary>
        void SetupGame();

        /// <summary>
        /// Plays the game.
        /// </summary>
        void PlayGame();

        /// <summary>
        /// Processes the end result of the game.
        /// </summary>
        void EndGame();

        /// <summary>
        /// Checks if the player would like to play again
        /// </summary>
        bool PlayAgain();
    }
}
