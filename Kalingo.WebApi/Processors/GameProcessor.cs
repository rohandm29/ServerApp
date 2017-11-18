using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Facades;

namespace Kalingo.WebApi.Processors
{
    public class GameProcessor
    {
        private readonly MinesBoomFacade _minesBoomFacade;

        public GameProcessor(MinesBoomFacade minesBoomFacade)
        {
            _minesBoomFacade = minesBoomFacade;
        }

        public async Task<int> ExecuteNewGame(int gameTypeId, int userId)
        {
            int gameId;

            switch (gameTypeId)
            {
                case 1: gameId = await _minesBoomFacade.ProcessNewGame(userId);
                    break;

                case 2:
                    
                default: gameId = 0;
                    break;
            }

            return gameId;
        }

        public async Task<GameResult> ExecuteSelection(GameArgs gameArgs)
        {
            // can be any type of gameresult
            dynamic gameResult;

            switch (gameArgs.GameTypeId)
            {
                case 1:
                    gameResult = await _minesBoomFacade.ProcessSelection((MinesboomSelectionRequest) gameArgs);
                    break;

                case 2:
                    gameResult = default(GameResult);
                    break;

                default:
                    gameResult = default(GameResult);
                    break;
            }

            return gameResult;
        }

        public async Task TerminateGame(GameArgs gameArgs)
        {
            switch (gameArgs.GameTypeId)
            {
                case 1:
                    await _minesBoomFacade.TerminateGame(gameArgs.GameId);
                    break;
            }
        }
    }
}