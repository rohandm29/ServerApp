using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Cleaner;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Domain.Facades
{
    public class MinesBoomFacade
    {
        private readonly MinesBoomService _minesBoomService;
        private readonly MinesBoomCreationEngine _minesBoomCreationEngine;
        private readonly MinesBoomCleaner _cleaner;

        public MinesBoomFacade(MinesBoomService minesBoomService, MinesBoomCreationEngine minesBoomCreationEngine, MinesBoomCleaner cleaner) 
        {
            _minesBoomService = minesBoomService;
            _minesBoomCreationEngine = minesBoomCreationEngine;
            _cleaner = cleaner;
        }

        public async Task<int> ProcessNewGame(int userId)
        {
            try
            {
                var gameId = await _minesBoomCreationEngine.NewMinesBoom(userId);

                return gameId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<MinesboomSelectionResponse> ProcessSelection(MinesboomSelectionRequest gameArgs)
        {
            var mbSession = await _minesBoomService.ProcessSelection(gameArgs);

            await _cleaner.CloseIfGameOver(mbSession);

            return mbSession.GameResult;
        }

        
        public async Task TerminateGame(int gameId)
        {
            await _cleaner.Terminate(gameId);
        }
    }
}
