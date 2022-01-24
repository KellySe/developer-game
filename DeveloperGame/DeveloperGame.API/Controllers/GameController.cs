using DeveloperGame.Repositories.Datasources;
using DeveloperGame.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperGame.API.Controllers
{
    /// <summary>
    /// Add new APIs. Suggestions -
    /// Get all games (use the default get route)
    /// Add game.
    /// Get available achievements for a particular game.
    /// Add an achievement to a particular game.
    /// Get get game high score table.
    /// Add a score to a game for a particular user.
    /// Get game with high scores and high score table.
    /// Add a score for a player in a particular game.
    /// Anything else you can think of - challenge yourself.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService, IDeveloperGameDb developerGameDb)
        {
            _logger = logger;
            this.gameService = gameService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
