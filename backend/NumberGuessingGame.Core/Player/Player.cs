using System.Collections.Generic;

namespace NumberGuessingGame.Core.Player
{
    public class Player
    {
        public string Name { get; set; }
        public List<Game.Game> GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int TotalTries { get; set; }
    }
}
