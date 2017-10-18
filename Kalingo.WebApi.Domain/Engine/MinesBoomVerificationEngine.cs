using System.Threading.Tasks;
using System.Web.Http.Results;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class MinesBoomVerificationEngine
    {
        private readonly MinesBoomCache _minesBoomCache;

        public MinesBoomVerificationEngine(MinesBoomCache minesBoomCache)
        {
            _minesBoomCache = minesBoomCache;
        }

        /// <summary>
        /// Check if the user selection is correct and return the game state and result
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        public async Task<MinesBoomSession> CheckUserSelection(MinesBoomArgs gameArgs)
        {
            var gameData = FetchDataFromCache(gameArgs.GameId);

            if (gameData == null)
            {
                return MinesBoomSession.CreateNotFound(gameArgs.UserId, NotFound(gameArgs.GameId), null);
            }

            var result = IsSelectionCorrect(gameArgs, gameData);

            return MinesBoomSession.Create(gameArgs.UserId, result, gameData);
        }

        // Get the game data from cache
        private MinesBoomGameState FetchDataFromCache(int gameId)
        {
            lock ("CacheMayExpire")
            {
                if (_minesBoomCache.IsAlive(gameId))
                {
                    return _minesBoomCache.GetData(gameId).Result;
                }
            }

            return null;
        }

        // Check if selection is correct and increment Wins 
        private MinesBoomGameResult IsSelectionCorrect(MinesBoomArgs mbArgs, MinesBoomGameState mbGameState)
        {
            var selectionExist = mbGameState.HasSelection(mbArgs.SelectedOption);
            
            var result = CreateResult(selectionExist, mbArgs);

            return result;
        }

        private MinesBoomGameResult CreateResult(bool selectionCorrect, MinesBoomArgs args)
        {
            var gameResult = new MinesBoomGameResult(args.GameId, selectionCorrect, args.SelectedOption.ToString(), "");

            return gameResult;
        }

        private MinesBoomGameResult NotFound(int gameId)
        {
            return new MinesBoomGameResult(gameId: gameId, selectionCorrect: false, randomSequence: null, comment: "The game not found");
        }
    }
}
