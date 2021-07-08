using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NumberGuessingGame.Core;
using NumberGuessingGame.Core.Game;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Controllers
{
    [ApiController]
    [Route("numberGuessingGame")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Player>> CreateLeaderboardRequest()
        {
            var leaderboard = PlayerStorage.CreateLeaderboard();

            return Ok(leaderboard);
        }

        [HttpPost]
        [Route("start")]
        public Game StartGameRequest(Player player)
        {
            var game = GameStorage.StartGame(player);

            return game;
        }
    }
}