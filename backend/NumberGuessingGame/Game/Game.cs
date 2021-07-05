using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberGuessingGame.Game
{
    public class Game
    {
        private readonly List<int> _numbers = new();
        private readonly Random _rndNumber = new();

        public Game()
        {
            NumberToGues = GenerateRandomNumber();
        }

        public string NumberToGues { get; private set; }

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

        public bool IsNumber(string input)
        {
            return int.TryParse(input, out var inputNumber) && inputNumber.ToString().Length == 4;
        }

        public bool IsWinner(string userInput)
        {
            return NumberToGues == userInput;
        }

        public Result GetResult(string userInput)
        {
            var splitRandomNumber = NumberToGues.ToCharArray();
            var splitUserInput = userInput.ToCharArray();

            var result = new Result();

            for (var i = 0; i < NumberToGues.Length; i++)
            {
                if (NumberToGues.Contains(splitUserInput[i]))
                {
                    result.IsInList++;
                }
                if (splitRandomNumber[i] == splitUserInput[i])
                {
                    result.IsInCorrectPlace++;
                }
            }

            return result;
        }
    }
}
