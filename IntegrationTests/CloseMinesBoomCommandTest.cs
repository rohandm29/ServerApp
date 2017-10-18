using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using IntegrationTests.Support;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class CloseMinesBoomCommandTest
    {
        private string _connectionString;
        private CreateMinesBoomCommand _createMinesBoomCommand;
        private DbHelper _dbHelper;

        [SetUp]
        public void SetUp()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["KalingoDb"].ConnectionString;
            _dbHelper = new DbHelper(_connectionString);
            _createMinesBoomCommand = new CreateMinesBoomCommand(_connectionString);
        }

        [Test]
        public async Task Terminate_the_game()
        {
            // arrange
            var userSelection = "1-2-3-4-5";
            var closeMinesBoomCommand = new CloseMinesBoomCommand(_connectionString);

            var gameId = await _createMinesBoomCommand.Execute(111, "1-2-3-4-5");
            var mbData = GetMbData(gameId);

            AppendUserSelections(mbData, userSelection);

            // act
            await closeMinesBoomCommand.Execute(mbData);

            var userGameData = await _dbHelper.GetUserGameMinesBoom(gameId);

            // assert
            Assert.IsTrue(userGameData.GameWon);
            Assert.IsTrue(userSelection.Contains(userGameData.UserSelection.TrimEnd('-')));
        }

        private static MinesBoomSession GetMbData(int gameId)
        {
            return MinesBoomSession.Create(1,
                new MinesBoomGameResult(gameId, true, null, null) {HasWon = true},
                new MinesBoomGameState(new[] {1, 2, 3, 4, 5}, 1, 1));
        }

        private static void AppendUserSelections(MinesBoomSession mbData, string userSelection)
        {
            var selection = userSelection.Split('-');

            selection.All(x => { mbData.GameState.AppendSelection(int.Parse(x)); return true;});
        }
    }
}
