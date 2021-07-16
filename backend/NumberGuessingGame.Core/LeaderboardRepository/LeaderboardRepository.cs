using System.Collections.Generic;
using System.Linq;

namespace NumberGuessingGame.Core.LeaderboardRepository
{
    public class LeaderboardRepository : ILeaderboardRepository<Player.Player>
    {
        private static List<Player.Player> _leaderboard;
        private int _playerId;
        private Player.Player _currentPlayer;

        public LeaderboardRepository()
        {
            _leaderboard = new List<Player.Player>();
        }
        
        public Player.Player Create(string name)
        {
            _playerId++;

            var player = new Player.Player
            {
                Id = _playerId,
                Name = name,
                GamesPlayed = new List<Game.Game>(),
                GamesWon = 0,
                TotalTries = 0
            };
            
            _leaderboard.Add(player);

            _currentPlayer = player;

            return player;
        }

        public Player.Player Get(int id)
        {
            if (_leaderboard.All(p => p.Id != id))
            {
                return null;
            }
            
            var player = _leaderboard.FirstOrDefault(p => p.Id == id);
            _currentPlayer = player;

            return player;
        }

        public List<Player.Player> GetAll()
        {
            return _leaderboard;
        }

        public void Add(Game.Game game)
        {
            if (game.Won)
            {
                _currentPlayer.GamesWon++;
            }

            _currentPlayer.GamesPlayed.Add(game);
            _currentPlayer.TotalTries += game.Tries;
        }
    }
}