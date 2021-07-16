using System;
using System.Collections.Generic;
using System.Linq;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Core.Game
{
    public static class GameLogic
    {
        private static readonly Random RndNumber = new();
        private static Game _game;
        private static int _gameId;
        private static string _numberToGuess;

        public static Game StartGame(int id)
        {
            _gameId++;
            _numberToGuess = GenerateRandomNumber();
                
            _game = new Game
            {
                GameId = _gameId,
                NumberToGuess = _numberToGuess,
                PlayerId = id,
                Won = false,
                Tries = 0,
                DigitsGuessed = 0,
                DigitsInCorrectPlaces = 0,
                GameEnded = false
            };

            return _game;
        }

        private static string GenerateRandomNumber()
        {
            var tempNumList = new List<int>();
            
            var count = 0;

            do
            {
                var number = RndNumber.Next(9);

                if (!tempNumList.Contains(number))
                {
                    tempNumList.Add(number);
                    count++;
                }
            } while (count < 4);

            return string.Join("", tempNumList);
        }

        public static bool IsValidNumberInput(string input)
        {
            var longerThanFourDigits = false;

            var notIntFlag = input.Any(c => !char.IsDigit(c));

            if (input.Length > 4)
            {
                longerThanFourDigits = true;
            }

            return !notIntFlag && !longerThanFourDigits;
        }

        public static Game ReturnGame()
        {
            return _game;
        }

        public static Game SetMoveReturnCurrentGame(string userInput)
        {
            _game.DigitsInCorrectPlaces = 0;
            _game.DigitsGuessed = 0;
            
            var splitRandomNumber = _numberToGuess.ToCharArray();
            var splitUserInput = userInput.ToCharArray();

            for (var i = 0; i < _numberToGuess.Length; i++)
            {
                if (_numberToGuess.Contains(splitUserInput[i]))
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

        private static bool IsWinner()
        {
            return _game.DigitsInCorrectPlaces == 4;
        }

        private static void EndGame(Game game)
        {
            GameSession.GameSession.AddGameResultToPlayer(game);
        }
    }
}