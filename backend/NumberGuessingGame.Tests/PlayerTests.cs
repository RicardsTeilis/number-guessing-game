using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuessingGame.Core;
using NumberGuessingGame.Core.Player;

namespace NumberGuessingGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private readonly PlayerStorage _target;

        public PlayerTests()
        {
            _target = new PlayerStorage();
        }

        [TestMethod]
        public void GetPlayerScores_ReturnsPlayers()
        {
            // Act
            var returned = PlayerStorage.GetPlayerScores();

            var isTypeOfResult = returned is List<Player>;

            // Assert
            Assert.AreEqual(true, isTypeOfResult);
        }
    }
}