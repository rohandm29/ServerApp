using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace Kalingo.WebApi.UnitTests.Domain.Data.Cache
{
    [TestFixture]
    public class CacheTests
    {
        private MinesBoomCache _randomSequenceCache;

        [SetUp]
        public void SetUp()
        {
            _randomSequenceCache = new MinesBoomCache();
        }

        [Test]
        public async Task Should_add_and_retreive_a_random_sequence_from_cache()
        {
            // arrange
            const int gameId = 123;
            var randomSequence = new[] { 1, 2, 3, 4, 5 };

            var gameData = new MinesBoomGameState(randomSequence, 1, 1);

            // act
            await _randomSequenceCache.Add(gameId, gameData);

            var result = _randomSequenceCache.GetData(gameId).Result;

            // assert
            Assert.AreEqual(randomSequence, result.RandomSequence);
        }

        [TestCase(123, true)]
        [TestCase(111, false)]
        public async Task Should_return_true_if_alive(int gameId, bool expectedIsAlive)
        {
            // arrange
            var randomSequence = new[] { 1, 2, 3, 4, 5 };

            var gameData = new MinesBoomGameState(randomSequence, 1, 1);
            
            // act
            await _randomSequenceCache.Add(gameId, gameData);

            var isAlive = _randomSequenceCache.IsAlive(gameId);

            // arrange
            Assert.IsTrue(isAlive);
        }

        [Test]
        public async Task Should_remove_from_cache()
        {
            // arrange
            const int gameId = 123;
            var randomSequence = new[] { 1, 2, 3, 4, 5 };

            var gameData = new MinesBoomGameState(randomSequence, 1, 1);

            // act
            await _randomSequenceCache.Add(gameId, gameData);
            var isAliveBefore = _randomSequenceCache.IsAlive(gameId);

            _randomSequenceCache.Remove(gameId);
            var isAliveAfter = _randomSequenceCache.IsAlive(gameId);

            // assert
            Assert.IsTrue(isAliveBefore);
            Assert.IsFalse(isAliveAfter);
        }
    }
}
