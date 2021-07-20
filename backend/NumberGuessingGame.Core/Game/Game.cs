using System.Collections.Generic;

namespace NumberGuessingGame.Core.Game
{
    public class Game
    {
        public int GameId { get; set; }
        public string NumberToGuess { get; set; }
        public int PlayerId { get; set; }
        public bool Won { get; set; }
        public int Tries { get; set; }
        public List<string> PreviousTries { get; set; }
        public int DigitsGuessed { get; set; }
        public int DigitsInCorrectPlaces { get; set; }
        public bool GameEnded { get; set; }
    }
}
