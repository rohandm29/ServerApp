using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace Kalingo.WebApi.UnitTests.Domain.Engine
{
    [TestFixture]
    public class RandomGeneratorTests
    {
        private RandomGenerator _randomGenerator;

        [SetUp]
        public void SetUp()
        {
            _randomGenerator = new RandomGenerator();
        }

        [TestCase(4)]
        [TestCase(1)]
        [TestCase(15)]
        public void Return_correct_number_of_random_numbers(int count)
        {
            // arrange
            var set = new NumberSet(1, 16);

            // act
            var result = _randomGenerator.GetSequence(count, set);

            // assert
            Assert.AreEqual(count, result.Length);
        }
    }
}
