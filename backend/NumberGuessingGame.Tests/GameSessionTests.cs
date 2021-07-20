using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuessingGame.Core.Game;
using NumberGuessingGame.Core.GameSession;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Tests
{
    [TestClass]
    public class GameSessionTests
    {
        private readonly GameSession _gameSession;
        
        public GameSessionTests()
        {
            _gameSession = new GameSession();
        }

        [TestMethod]
        public void IsValidPlayerName_StringGiven_ReturnsTrue()
        {
            // Arrange
            const string name = "John";

            // Act
            var returned = GameSession.IsValidPlayerName(name);
            
            // Assert
            Assert.AreEqual(true, returned);
        }

        [TestMethod]
        public void IsValidPlayerName_WhitespaceGiven_ReturnsFalse()
        {
            // Arrange
            const string name = " ";

            // Act
            var returned = GameSession.IsValidPlayerName(name);
            
            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void IsValidPlayerName_EmptyString_ReturnsFalse()
        {
            // Arrange
            const string name = "";

            // Act
            var returned = GameSession.IsValidPlayerName(name);
            
            // Assert
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void CreateNewPlayer_NameGivenReturnsPlayerWithGivenName_ReturnsTrue()
        {
            // Arrange
            const string name = "John";

            // Act
            var returned = GameSession.CreateNewPlayer(name);
            var returnedName = returned.Name;
            
            // Assert
            Assert.AreEqual(name, returnedName);
        }

        [TestMethod]
        public void GetPlayerById_ExistingIdIdGiven_ReturnsPlayer()
        {
            // Arrange
            const int id = 1;
            GameSession.CreateNewPlayer("Philip");
            
            // Act
            var returned = GameSession.GetPlayerById(id);
            var returnedId = returned.Id;
            
            // Assert
            Assert.AreEqual(id,returnedId);
        }

        [TestMethod]
        public void GetPlayerById_NonExistingIdIdGiven_ReturnsNull()
        {
            // Arrange
            const int id = 2;
            GameSession.CreateNewPlayer("Philip");
            
            // Act
            var returned = GameSession.GetPlayerById(id);
            
            // Assert
            Assert.AreEqual(null,returned);
        }
    }
}
