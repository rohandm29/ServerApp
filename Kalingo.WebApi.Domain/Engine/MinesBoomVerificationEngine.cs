using System.Linq;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.WebApi.Domain.Exceptions;

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
        public async Task<MinesBoomSession> CheckUserSelection(MinesboomSelectionRequest gameArgs)
        {
            var gameData = FetchDataFromCache(gameArgs.GameId);

            if (gameData == null)
            {
                throw new GameNotFoundException("Game Not Found");
            }

            var result = IsSelectionCorrect(gameArgs, gameData);

            return MinesBoomSession.Create(gameArgs.UserId, result, gameData);
        }

        // Get the game data from cache
        private MinesBoomGameState FetchDataFromCache(int gameId)
        {
            //lock ("CacheMayExpire")
            //{
                if (_minesBoomCache.IsAlive(gameId))
                {
                    return _minesBoomCache.GetData(gameId).Result;
                }
            //}

            return null;
        }

        // Check if selection is correct and increment Wins 
        private MinesboomSelectionResponse IsSelectionCorrect(MinesboomSelectionRequest mbArgs, MinesBoomGameState mbGameState)
        {
            var alreadySelected = false;

            if(mbGameState.UserSelections.Any())
                alreadySelected = mbGameState.UserSelections.Contains(mbArgs.SelectedOption);

            if (alreadySelected)
            {
                throw new DuplicateSelectionException("Duplicate Selection");
            }

            var selectionExist = mbGameState.HasSelection(mbArgs.SelectedOption) && !alreadySelected;

            var result = CreateResult(selectionExist, mbArgs);

            return result;
        }

        private MinesboomSelectionResponse CreateResult(bool selectionCorrect, MinesboomSelectionRequest args)
        {
            var gameResult = new MinesboomSelectionResponse(args.GameId, selectionCorrect, args.SelectedOption.ToString());

            return gameResult;
        }
    }
}
