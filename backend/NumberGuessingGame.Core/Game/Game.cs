namespace NumberGuessingGame.Core.Game
{
    public class Game
    {
        public string NumberToGuess { get; set; }
        public string PlayerName;
        public bool Won { get; set; }
        public int Tries { get; set; }
        public int DigitsGuessed { get; set; }
        public int DigitsInCorrectPlaces { get; set; }
        public bool GameEnded { get; set; }
    }
}
