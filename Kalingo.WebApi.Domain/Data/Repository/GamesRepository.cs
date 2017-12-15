using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class GamesRepository
    {
        private readonly CreateMinesBoomCommand _createMinesBoomCommand;
        private readonly CloseMinesBoomCommand _closeMinesBoomCommand;
        private readonly TerminateMinesBoomCommand _terminateMinesBoomCommand;
        private readonly AllocateCoinsCommand _allocateCoinsCommand;
        private readonly GetMinesboomSettingsQuery _getMinesboomSettingsQuery;

        public GamesRepository(CreateMinesBoomCommand createMinesBoomCommand, 
            CloseMinesBoomCommand closeMinesBoomCommand, 
            TerminateMinesBoomCommand terminateMinesBoomCommand,
            AllocateCoinsCommand allocateCoinsCommand,
            GetMinesboomSettingsQuery getMinesboomSettingsQuery)
        {
            _createMinesBoomCommand = createMinesBoomCommand;
            _closeMinesBoomCommand = closeMinesBoomCommand;
            _terminateMinesBoomCommand = terminateMinesBoomCommand;
            _allocateCoinsCommand = allocateCoinsCommand;
            _getMinesboomSettingsQuery = getMinesboomSettingsQuery;
        }

        public async Task<int> CreateMinesBoom(NewMinesboomRequest minesboomRequest, string getDelimatedSequence)
        {
            return await _createMinesBoomCommand.Execute(minesboomRequest, getDelimatedSequence);
        }

        public async Task CloseMinesBoom(MinesBoomSession minesBoomSession)
        {
            await _closeMinesBoomCommand.Execute(minesBoomSession);
        }

        public async Task TerminateMinesBoom(int userId, int gameId, int[] userSelection, List<int> randomSequence, bool expired)
        {
            await _terminateMinesBoomCommand.Execute(userId, gameId, userSelection, randomSequence, expired);
        }

        public async Task AllocateCoins(MinesBoomSession minesBoomSession)
        {
            await _allocateCoinsCommand.Execute(minesBoomSession);
        }

        public IEnumerable<Settings> GetMinesboomSettings()
        {
            return _getMinesboomSettingsQuery.Execute();
        }
    }
}
