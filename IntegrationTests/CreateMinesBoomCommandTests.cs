﻿using System.Configuration;
using System.Threading.Tasks;
using IntegrationTests.Support;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using NUnit.Framework;

namespace IntegrationTests
{
    public class CreateMinesBoomCommandTests
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
        public async Task Should_create_a_new_game()
        {
            // arrange
            const string randomSequence = "1-2-3-4-5";
            const string userId = "111";

            // act
            var gameId = await _createMinesBoomCommand.Execute(userId, ""); //, randomSequence);

            var gameData = await _dbHelper.GetUserGameMinesBoom(gameId);

            // assert
            Assert.AreEqual(randomSequence, gameData.RandomSequence);
            Assert.AreEqual(userId, gameData.UserId);
        }
    }
}
