using System;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class GamesRepository
    {
        private readonly CreateMinesBoomCommand _createMinesBoomCommand;
        private readonly CloseMinesBoomCommand _closeMinesBoomCommand;
        private readonly TerminateMinesBoomCommand _terminateMinesBoomCommand;
        private readonly AllocateGoldCoinsCommand _allocateGoldCoinsCommand;

        public GamesRepository(CreateMinesBoomCommand createMinesBoomCommand, 
            CloseMinesBoomCommand closeMinesBoomCommand, 
            TerminateMinesBoomCommand terminateMinesBoomCommand,
            AllocateGoldCoinsCommand allocateGoldCoinsCommand)
        {
            _createMinesBoomCommand = createMinesBoomCommand;
            _closeMinesBoomCommand = closeMinesBoomCommand;
            _terminateMinesBoomCommand = terminateMinesBoomCommand;
            _allocateGoldCoinsCommand = allocateGoldCoinsCommand;
        }

        public async Task<int> CreateMinesBoom(int userId, string randomSequence)
        {
            return await _createMinesBoomCommand.Execute(userId, randomSequence);
        }

        public async Task CloseMinesBoom(MinesBoomSession minesBoomSession)
        {
            await _closeMinesBoomCommand.Execute(minesBoomSession);
        }

        public async Task TerminateMinesBoom(int gameId, string userSelection)
        {
            await _terminateMinesBoomCommand.Execute(gameId, userSelection);
        }

        public async Task AllocateGoldCoins(MinesBoomSession minesBoomSession)
        {
            await _allocateGoldCoinsCommand.Execute(minesBoomSession.UserId, minesBoomSession.GameId);
        }
    }
}
