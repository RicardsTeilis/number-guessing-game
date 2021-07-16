using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NumberGuessingGame.Core.Game;
using NumberGuessingGame.Core.GameSession;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Controllers
{
    [ApiController]
    [Route("")]
    public class GameController : ControllerBase
    {
        private GameSession _gameSession;
        
        [HttpGet]
        [Route("startSession")]
        public ActionResult<List<Player>> CreateNewGameSessionRequest()
        {
            _gameSession = new GameSession();
            return Ok(GameSession.ReturnLeaderboard());
        }

        [HttpGet]
        [Route("leaderboard")]
        public ActionResult<List<Player>> ReturnLeaderBoardRequest()
        {
            return GameSession.ReturnLeaderboard();
        }

        [HttpPost]
        [Route("player")]
        public ActionResult<Player> CreateNewPlayerRequest(string name)
        {
            var isValidPlayerName = GameSession.IsValidPlayerName(name);

            if (!isValidPlayerName)
            {
                return BadRequest("The name cannot be empty");
            }
            
            return Created("",GameSession.CreateNewPlayer(name)) ;
        }

        [HttpGet]
        [Route("player/{id:int}")]
        public ActionResult<Player> GetPlayerByIdRequest(int id)
        {
            var player = GameSession.GetPlayerById(id);

            if (player == null)
            {
                return NotFound("No such player");
            }

            return player;
        }

        [HttpGet]
        [Route("game/{id:int}")]
        public IActionResult StartGameRequest(int id)
        {
            var game = GameLogic.StartGame(id);

            return Created("", game);
        }

        [HttpGet]
        [Route("game/getGame")]
        public Game GetGame()
        {
            return GameLogic.ReturnGame();
        }

        [HttpPost]
        [Route("game")]
        public ActionResult<Game> SetMoveReturnCurrentGameRequest(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("The input cannot be empty");
            }
            
            var isValidInput = GameLogic.IsValidNumberInput(input);

            if (!isValidInput)
            {
                return BadRequest("The input is not valid");
            }

            var getGame = GameLogic.SetMoveReturnCurrentGame(input);
            
            return Ok(getGame);
        }
    }
}