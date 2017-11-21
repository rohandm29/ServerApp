using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Cleaner;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Exceptions;
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
            try
            {
                var mbSession = await _minesBoomService.ProcessSelection(gameArgs);

                await _cleaner.CloseIfGameOver(mbSession);

                return mbSession.GameResult;
            }
            catch (GameNotFoundException e)
            {
                return HandleException(gameArgs, e.Message, MinesboomCodes.NotFound);
            }
            catch (DuplicateSelectionException e)
            {
                return HandleException(gameArgs, e.Message, MinesboomCodes.Duplicate);
            }
            catch (Exception e)
            {
                return HandleException(gameArgs, e.Message, MinesboomCodes.Invalid);
            }
        }

        public async Task TerminateGame(GameArgs gameArgs, bool expired)
        {
            try
            {
                await _cleaner.Terminate(gameArgs.UserId, gameArgs.GameId , expired);
            }
            catch (Exception)
            {
                // log
            }
        }

        private static MinesboomSelectionResponse HandleException(MinesboomSelectionRequest gameArgs, string message,
            MinesboomCodes code)
        {
            var response = new MinesboomSelectionResponse(gameArgs.GameId, false, gameArgs.SelectedOption.ToString())
            {
                ErrorCode = code
            };
            response.Errors.Add(message);
            return response;
        }
    }
}
