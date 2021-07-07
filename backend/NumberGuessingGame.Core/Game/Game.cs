namespace NumberGuessingGame.Core.Game
{
    public class Game
    {
        internal string NumberToGuess { get; }
        internal Player.Player Player;
        internal bool Won;
        internal int Tries { get; set; }
        internal int DigitsGuessed { get; set; }
        internal int DigitsInCorrectPlaces { get; set; }
        internal bool GameEnded;

        public Game(string numberToGuess, Player.Player player)
        {
            NumberToGuess = numberToGuess;
            Player = player;
            Won = false;
            Tries = 0;
            DigitsGuessed = 0;
            DigitsInCorrectPlaces = 0;
            GameEnded = false;
        }
    }
}
