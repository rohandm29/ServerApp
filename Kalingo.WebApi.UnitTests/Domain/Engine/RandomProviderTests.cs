using FakeItEasy;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace Kalingo.WebApi.UnitTests.Domain.Engine
{
    [TestFixture]
    public class RandomProviderTests
    {
        private RandomProvider _randomProvider;
        private RandomGenerator _fakeRandomGenerator;

        [SetUp]
        public void SetUp()
        {
            _fakeRandomGenerator = A.Fake<RandomGenerator>();
            _randomProvider = new RandomProvider(_fakeRandomGenerator);
        }

        [Test]
        public void Return_random_numbers_in_correct_format()
        {
            // arrange
            A.CallTo(() => _fakeRandomGenerator.GetSequence(A<int>.Ignored, A<NumberSet>.Ignored)).Returns(new[] { 1,2,3,4 });
            var expectedSequence = "1;2;3;4";

            // act
            var randomSequence = _randomProvider.CreateRandomSequenceForMinesBoom(); 

            // assert
            Assert.AreEqual(expectedSequence, randomSequence);
        }
}
}
