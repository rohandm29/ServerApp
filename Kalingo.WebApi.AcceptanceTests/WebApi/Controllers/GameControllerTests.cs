using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.AcceptanceTests.WebApi.Support;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace Kalingo.WebApi.AcceptanceTests.WebApi.Controllers
{
    [TestFixture]
    public class GameControllerTests
    {
        private StartUpTestServer _testServer;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testServer = new StartUpTestServer();
            _testServer.StartServer();
        }

        [Test]
        public void Should_create_MinesBoom()
        {
            // arrange
            var gamesArgs = new MinesboomSelectionRequest(1, 123, 1, true);

            // act
            // assert
            var gameId = 0;
            Assert.DoesNotThrowAsync(async () => gameId = await _testServer.SendRequest<int>("join", gamesArgs));
            
            //Teardown
            DbHelper.DeleteUserGames(gameId);
        }

        [Test]
        public async Task Should_submit_selection_to_MinesBoom()
        {
            // arrange
            var gamesArgs = new MinesboomSelectionRequest(1, 123, 1, true);

            // act
            var gameId = await _testServer.SendRequest<int>("join", gamesArgs);

            var gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 5, true));

            // assert
            Assert.IsNotNull(gameResult);
        }

        [Test]
        public async Task Should_win_or_lose_a_Game()
        {
            // arrange
            var gamesArgs = new MinesboomSelectionRequest(1, 123, 1, true);

            // act
            var gameId = await _testServer.SendRequest<int>("join", gamesArgs);

            var gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 1, true));
            gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 2, true));
            gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 13, true));
            gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 4, true));
            gameResult = await _testServer.SendRequest<GameResult>("submit", new MinesboomSelectionRequest(gameId, 123, 15, true));

            // assert
            Assert.IsNotNull(gameResult);
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            _testServer.DisposeServer();
        }
    }
}
