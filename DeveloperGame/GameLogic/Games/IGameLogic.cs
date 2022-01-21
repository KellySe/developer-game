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
        void Initialise();

        /// <summary>
        /// Returns prompts displayed to the user during the game.
        /// Should describe the current state of the game and request input from the user.
        /// </summary>
        string GetNextPrompt();

        /// <summary>
        /// Processes the user entry for the last prompt.
        /// If the user entry completes the game this method should set <see cref="GameComplete"/> to true.
        /// </summary>
        /// <param name="entry">The user response to <see cref="GetNextPrompt"/></param>
        void HandlePlayerResponse(string entry);
    }
}
