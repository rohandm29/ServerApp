using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace Kalingo.WebApi.UnitTests.Domain.Engine
{
    [TestFixture]
    public class MinesBoomVerifierTests
    {
        private MinesBoomCache _cache;
        private MinesBoomVerificationEngine _verifier;

        [SetUp]
        public void SetUp()
        {
            _cache = new MinesBoomCache(null);
            _verifier = new MinesBoomVerificationEngine(_cache);
        }

        [TestCase(3, true)]
        [TestCase(12, true)]
        [TestCase(6, false)]
        [TestCase(15, false)]
        public async Task Should_check_if_selection_is_correct(int selection, bool win)
        {
            // arrange
            var gameId = 123;
            var gameData = new MinesBoomGameState(1, new[] { 1, 3, 5, 7, 12 }, 1, 1);

            await _cache.Add(gameId, gameData);

            var gameArgs = new MinesboomSelectionRequest(gameId, 111, selection);

            // act
            var result = await _verifier.CheckUserSelection(gameArgs);

            // assert
            Assert.AreEqual(win, result.GameResult.SelectionCorrect);
        }
    }
}
