using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuessingGame.Core
{
    public class GameStorage
    {
        private static readonly List<int> _numbers = new();
        private static readonly Random _rndNumber = new();
        private static Game.Game _game;

        public static Game.Game StartGame(Player.Player player)
        {
            _game = new Game.Game(GenerateRandomNumber(), new Player.Player{ Name = player.Name });

            return _game;
        }

        public bool IsValidNumberInput(string input)
        {
            return int.TryParse(input, out var inputNumber) && inputNumber.ToString().Length == 4;
        }

        public Game.Game SetMoveReturnCurrentGame(string userInput)
        {
            var splitRandomNumber = _game.NumberToGuess.ToCharArray();
            var splitUserInput = userInput.ToCharArray();

            for (var i = 0; i < _game.NumberToGuess.Length; i++)
            {
                if (_game.NumberToGuess.Contains(splitUserInput[i]))
                {
                    _game.DigitsGuessed++;
                }
                
                if (splitRandomNumber[i] == splitUserInput[i])
                {
                    _game.DigitsInCorrectPlaces++;
                }
            }

            var isWinner = IsWinner();

            if (isWinner)
            {
                _game.Won = true;
                _game.GameEnded = true;
                
                EndGame(_game);
            }

            _game.Tries++;

            if (_game.Tries == 8 && !isWinner)
            {
                _game.Won = false;
                _game.GameEnded = true;
                
                EndGame(_game);
            }

            return _game;
        }

        private bool IsWinner()
        {
            return _game.DigitsInCorrectPlaces == 4;
        }

        private static string GenerateRandomNumber()
        {
            var count = 0;

            do
            {
                var number = _rndNumber.Next(9);

                if (!_numbers.Contains(number))
                {
                    _numbers.Add(number);
                    count++;
                }
            } while (count < 4);

            return string.Join("", _numbers);
        }

        private void EndGame(Game.Game game)
        {
            PlayerStorage.AddPlayerScore(game);
        }
    }
}