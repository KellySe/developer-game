using DeveloperGame.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperGame.API.Controllers
{
    /// <summary>
    /// Add new APIs. Suggestions -
    /// Get all players (use the default get route)
    /// Add player.
    /// Get player's achievements - maybe at the route "player/{playerId}"
    /// Add an achievemnet for a player
    /// Get player's achievements and scores for a specific game - consider what the route could be.
    /// Get player with their achievements.
    /// Add a score for a player in a particular game.
    /// Add/list friends for a player (you will need to add a new fake DB table to <see cref="IDeveloperGameDb"/> to store this data)
    /// Anything else you can think of - challenge yourself.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IPlayerService playerService;

        public PlayerController(ILogger<GameController> logger, IPlayerService playerService)
        {
            _logger = logger;
            this.playerService = playerService;
        }
    }
}
