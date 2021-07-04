using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberGuessingGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game.Game _target;

        public GameTests()
        {
            _target = new Game.Game();
        }

        [TestMethod]
        public void GenerateRandomNumber_ReturnNumberString()
        {
            // Act
            var returned = _target.GenerateRandomNumber();
        }
    }
}
