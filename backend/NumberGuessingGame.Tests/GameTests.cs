using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuessingGame.Core;
using NumberGuessingGame.Core.Game;
using NumberGuessingGame.Core.Player;

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

        [TestMethod]
        public void StartGame_PlayerGiven_ReturnsCurrentGame()
        {
            // Arrange
            var player = new Player{ Name = "John" };
            
            // Act
            var returned = _target.StartGame(player);
            
            var isTypeOfResult = returned is Game;
            
            // Assert
            Assert.AreEqual(true, isTypeOfResult);
        }

        [TestMethod]
        public void SetMoveReturnCurrentGame_UserInputGiven_ReturnsCurrentGame()
        {
            // Arrange
            const string userInput = "1234";

            // Act
            _target.StartGame(new Player{ Name = "John" });
            
            var returnedResult = _target.SetMoveReturnCurrentGame(userInput);

            var isTypeOfResult = returnedResult is Game;

            // Assert
            Assert.AreEqual(true, isTypeOfResult);
        }
    }
}
