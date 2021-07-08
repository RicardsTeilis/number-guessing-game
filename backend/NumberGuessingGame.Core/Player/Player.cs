using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NumberGuessingGame.Core.Player
{
    public class Player
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gamesPlayed")]
        public List<Game.Game> GamesPlayed { get; set; }
        [JsonPropertyName("gamesWon")]
        public int GamesWon { get; set; }
        [JsonPropertyName("totalTries")]
        public int TotalTries { get; set; }
    }
}
