using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NumberGuessingGame.Core.Game;
using NumberGuessingGame.Core.GameSession;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Controllers
{
    [ApiController]
    [Route("numberGuessingGame")]
    public class GameController : ControllerBase
    {
        private GameSession _gameSession;
        
        [HttpGet]
        public ActionResult<List<Player>> CreateNewGameSessionRequest()
        {
            _gameSession = new GameSession();
            
            return Ok(_gameSession.ReturnLeaderboard());
        }

        [HttpGet]
        [Route("leaderboard")]
        public ActionResult<List<Player>> ReturnLeaderBoardRequest()
        {
            return _gameSession.ReturnLeaderboard();
        }

        [HttpPut]
        [Route("player")]
        public ActionResult<Player> CreateNewPlayerRequest(string name)
        {
            var isValidPlayerName = _gameSession.IsValidPlayerName(name);

            if (!isValidPlayerName)
            {
                return BadRequest("The name cannot be empty");
            }
            
            return Created("",_gameSession.CreateNewPlayer(name)) ;
        }

        [HttpGet]
        [Route("player/{id:int}")]
        public ActionResult<Player> GetPlayerByIdRequest(int id)
        {
            var player = _gameSession.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpGet]
        [Route("game")]
        public IActionResult StartGameRequest(Player player)
        {
            var game = GameLogic.StartGame(player);

            if (game == null)
            {
                return BadRequest("The number has to contain only four digits");
            }

            return Created("", game);
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