using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuessingGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private readonly Core.GameStorage _target;

        public GameTests()
        {
            _target = new Core.GameStorage();
        }

        [TestMethod]
        public void GenerateRandomNumber_IsUniqueDigits_ReturnTrue()
        {
            // Arrange
            bool expectedIsUniqueDigits = true;

            // Act
            string returnedString = _target.NumberToGues;
            string[] numStringArray = returnedString.Split();
            List<int> numIntList = new();

            for (int i = 0; i < numStringArray.Length; i++)
            {
                numIntList.Add(int.Parse(numStringArray[i]));
            }

            bool returnedIsUniqueDigits = numIntList.Distinct().Count() == numStringArray.Length;

            // Assert
            Assert.AreEqual(expectedIsUniqueDigits, returnedIsUniqueDigits);
        }

        [TestMethod]
        public void IsNumber_StringOfCharactersAndNumbersGiven_ReturnsFalse()
        {
            // Arrange
            var input = "e_R3";

            // Act
            var returned = _target.IsNumber(input);

            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void IsNumber_NumberLongerThanFourDigitsGiven_ReturnsFalse()
        {
            // Arrange
            var input = "12345";

            // Act
            var returned = _target.IsNumber(input);

            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void IsNumber_StringOfNumbersGiven_ReturnsTrue()
        {
            // Arrange
            var input = "1234";

            // Act
            var returned = _target.IsNumber(input);

            // Assert
            Assert.AreEqual(true, returned);
        }

        [TestMethod]
        public void IsWinner_NumberStringGiven_ReturnsFalse()
        {
            // Arrange
            var userInput = "1234";

            // Act
            var returned = _target.IsWinner(userInput);
        }

        [TestMethod]
        public void GetResult_UserInputGiven_ReturnsIsResult()
        {
            // Arrange
            var userInput = "1234";

            // Act
            var returnedResult = _target.GetResult(userInput);

            bool isTypeOfResult = returnedResult is Game.Result;

            // Assert
            Assert.AreEqual(true, isTypeOfResult);
        }
    }
}
