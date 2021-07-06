namespace NumberGuessingGame.Core.Game
{
    public class Game
    {
        internal string NumberToGuess { get; }
        private Player.Player _player;
        internal bool Won;
        internal int Tries { get; set; }
        internal int DigitsGuessed { get; set; }
        internal int DigitsInCorrectPlaces { get; set; }

        public Game(string numberToGuess, Player.Player player)
        {
            NumberToGuess = numberToGuess;
            _player = player;
            Won = false;
            Tries = 0;
            DigitsGuessed = 0;
            DigitsInCorrectPlaces = 0;
        }
    }
}
