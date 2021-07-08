using System.Collections.Generic;
using System.Linq;

namespace NumberGuessingGame.Core
{
    public class PlayerStorage
    {
        internal static List<Player.Player> Leaderboard;

        public static List<Player.Player> CreateLeaderboard()
        {
            Leaderboard = new List<Player.Player>();

            return Leaderboard;
        }

        internal static void AddPlayerScore(Game.Game result)
        {
            var player = result.Player;
            
            player.GamesPlayed.Add(result);

            player.TotalTries += result.Tries;

            if (result.Won)
            {
                player.GamesWon++;
            }
            
            AddPlayerToLeaderboard(player, result);
        }

        private static void AddPlayerToLeaderboard(Player.Player player, Game.Game result)
        {
            if (!Leaderboard.Contains(player))
            {
                Leaderboard.Add(player);
            }
            else
            {
                var playerToUpdate = Leaderboard.FirstOrDefault(p => p.Name == player.Name);

                if (playerToUpdate != null)
                {
                    playerToUpdate.TotalTries += result.Tries;
                    playerToUpdate.GamesPlayed.Add(result);

                    if (result.Won)
                    {
                        playerToUpdate.GamesWon++;
                    }
                }
            }
        }

        public static List<Player.Player> GetPlayerScores()
        {
            return Leaderboard;
        }
    }
}