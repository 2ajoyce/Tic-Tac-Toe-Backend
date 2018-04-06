using NUnit.Framework;
using Moq;

using TicTacToe.Services;
using TicTacToe.Models;

namespace TicTacToeTests.Services
{
    [TestFixture]
    class GameStoreTests
    {
        private GameStore _gameStore;

        [SetUp]
        public void Setup()
        {
            _gameStore = new GameStore();
        }

        [Test]
        public void TestStart_shouldCallPrune_whenInvoked()
        {
            Game game = _gameStore.Start('a');
            Assert.Equals(game.FirstPlayer, 'a');
            _gameStore.Get()
        }
    }
}