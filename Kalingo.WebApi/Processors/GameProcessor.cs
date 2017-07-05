using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Entity;
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
            var gameId = 0;

            switch (gameTypeId)
            {
                case 1:
                    break;

                case 2:
                    gameId = await _minesBoomFacade.ProcessNewGame(userId);
                    break;
            }

            return gameId;
        }

        public async Task<GameResult> ExecuteSelection(GameArgs gameArgs)
        {
            try
            {
                // can be any type of gameresult
                dynamic gameResult;

                switch (gameArgs.GameTypeId)
                {
                    case 1:
                        gameResult = default(GameResult);
                        break;

                    case 2:
                        gameResult = await _minesBoomFacade.ProcessSelection((MinesBoomArgs)gameArgs);
                        break;

                    default: gameResult = default(GameResult);
                        break;
                }

                return gameResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}