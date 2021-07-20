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

        public static bool IsValidPlayerName(string name)
        {
            var trimmedName = name.Trim();
            
            return !string.IsNullOrEmpty(trimmedName);
        }

        public static Player.Player CreateNewPlayer(string name)
        {
            return _leaderboard.Create(name);
        }

        public static Player.Player GetPlayerById(int id)
        {
            return _leaderboard.Get(id);
        }

        public static void AddGameResultToPlayer(Game.Game game)
        {
            _leaderboard.Add(game);
        }

        public static List<Player.Player> ReturnLeaderboard()
        {
            return _leaderboard.GetAll();
        }

        public static List<Player.Player> ReturnFilteredLeaderboard(int filter)
        {
            return _leaderboard.GetFilteredLeaderboard(filter);
        }
    }
}