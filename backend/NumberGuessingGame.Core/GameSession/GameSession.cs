using System.Collections.Generic;

namespace NumberGuessingGame.Core.GameSession
{
    public class GameSession
    {
        private static LeaderboardRepository.LeaderboardRepository _leaderboard;

        public GameSession()
        {
            _leaderboard = new LeaderboardRepository.LeaderboardRepository();
        }

        public bool IsValidPlayerName(string name)
        {
            var trimmedName = name.Trim();
            
            return !string.IsNullOrEmpty(trimmedName);
        }

        public Player.Player CreateNewPlayer(string name)
        {
            return _leaderboard.Create(name);
        }

        public Player.Player GetPlayerById(int id)
        {
            return _leaderboard.Get(id);
        }

        public static void AddGameResultToPlayer(Game.Game game)
        {
            _leaderboard.Add(game);
        }

        public List<Player.Player> ReturnLeaderboard()
        {
            return _leaderboard.GetAll();
        }
    }
}