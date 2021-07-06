using System;
using System.Collections.Generic;

namespace NumberGuessingGame.Core
{
    public class GameStorage
    {
        private readonly List<int> _numbers = new();
        private readonly Random _rndNumber = new();
        private Game.Game _game;

        public Game.Game StartGame(string playerName)
        {
            _game = new Game.Game(GenerateRandomNumber(), new Player.Player{ Name = "John" });

            return _game;
        }

        public bool IsValidNumberInput(string input)
        {
            return int.TryParse(input, out var inputNumber) && inputNumber.ToString().Length == 4;
        }

        public Game.Game CurrentGame(string userInput)
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

            _game.Tries++;

            if (IsWinner())
            {
                _game.Won = true;
            }

            return _game;
        }

        private bool IsWinner()
        {
            return _game.DigitsInCorrectPlaces == 4;
        }

        private string GenerateRandomNumber()
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

        /*public bool IsWinner(string userInput)
        {
            return _game.NumberToGuess == userInput;
        }*/

        /*public TryResult GetResult(string userInput)
        {
            var splitRandomNumber = _game.NumberToGuess.ToCharArray();
            var splitUserInput = userInput.ToCharArray();

            var result = new TryResult();

            for (var i = 0; i < _game.NumberToGuess.Length; i++)
            {
                if (_game.NumberToGuess.Contains(splitUserInput[i]))
                {
                    result.IsInList++;
                }
                if (splitRandomNumber[i] == splitUserInput[i])
                {
                    result.IsInCorrectPlace++;
                }
            }

            return result;
        }*/
    }
}