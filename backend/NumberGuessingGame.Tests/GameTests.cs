using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuessingGame.Core;

namespace NumberGuessingGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private readonly GameStorage _target;

        public GameTests()
        {
            _target = new GameStorage();
        }

        [TestMethod]
        public void IsNumber_StringOfCharactersAndNumbersGiven_ReturnsFalse()
        {
            // Arrange
            const string input = "e_R3";

            // Act
            var returned = _target.IsValidNumberInput(input);

            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void IsNumber_NumberLongerThanFourDigitsGiven_ReturnsFalse()
        {
            // Arrange
            const string input = "12345";

            // Act
            var returned = _target.IsValidNumberInput(input);

            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void IsNumber_StringOfNumbersGiven_ReturnsTrue()
        {
            // Arrange
            const string input = "1234";

            // Act
            var returned = _target.IsValidNumberInput(input);

            // Assert
            Assert.AreEqual(true, returned);
        }

        /*[TestMethod]
        public void IsWinner_NumberStringGiven_ReturnsFalse()
        {
            // Arrange
            const string userInput = "1234";

            // Act
            var returned = _target.IsWinner(userInput);
            
            // Assert
            Assert.AreEqual(false, returned);
        }*/

        [TestMethod]
        public void GetResult_UserInputGiven_ReturnsIsResult()
        {
            // Arrange
            const string userInput = "1234";

            // Act
            var returnedResult = _target.GetResult(userInput);

            var isTypeOfResult = returnedResult is TryResult;

            // Assert
            Assert.AreEqual(true, isTypeOfResult);
        }
    }
}
