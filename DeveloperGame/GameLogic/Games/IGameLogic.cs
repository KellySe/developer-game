using GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.Games
{
    public interface IGameLogic
    {
        /// <summary>
        /// Indicates whether the game is complete.
        /// </summary>
        bool GameComplete { get; set; }

        /// <summary>
        /// Initialises the <see cref="IGameLogic"/> object;
        /// </summary>
        void Reinitialise();

        /// <summary>
        /// The text description of the game.
        /// </summary>
        string GetGameDescription();

        /// <summary>
        /// A collection of <see cref="GameConfigurationItem"/>s which are used to configure the game.
        /// </summary>
        IEnumerable<GameConfigurationItem> GetConfigurationItems();

        /// <summary>
        /// A prompt displayed to the user during the game. 
        /// Should describe the current state of the game and request input from the user.
        /// </summary>
        string RoundPrompt();

        /// <summary>
        /// Processes the user entry for the current game round and move the game to the next stage.
        /// If the user entry completes the game this method should set <see cref="GameComplete "/> to true.
        /// </summary>
        /// <param name="entry">The user response to <see cref="RoundPrompt"/></param>
        void PlayRound(string entry);

        /// <summary>
        /// Text that should be displayed to the user when the game ends.
        /// </summary>
        string EndGameText();

        /// <summary>
        /// A prompt that is displayed when the game is checking whether to restart the game.
        /// </summary>
        string PlayAgainPrompt();

        /// <summary>
        /// Processes the user choice in response to <see cref="PlayAgainPrompt"/>
        /// </summary>
        /// <param name="entry">The user reponse to <see cref="PlayAgainPrompt"/></param>
        bool PlayAgainResult(string entry);
    }
}
