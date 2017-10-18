using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Cleaner
{
    public class MinesBoomCleaner
    {
        private readonly MinesBoomCache _cache;
        private readonly GamesRepository _gamesRepository;

        public MinesBoomCleaner(MinesBoomCache cache, GamesRepository gamesRepository)
        {
            _cache = cache;
            _gamesRepository = gamesRepository;
        }

        public async Task CloseIfGameOver(MinesBoomSession minesBoomSession)
        {
            if (minesBoomSession.GameState.TotalChances <= 0)
            {
                await Close(minesBoomSession);
            }
            if (minesBoomSession.GameResult.HasWon)
            {
                await _gamesRepository.AllocateGoldCoins(minesBoomSession);
                await Close(minesBoomSession);
            }
        }
        
        public async Task Close(MinesBoomSession mb)
        {
            await _gamesRepository.CloseMinesBoom(mb);

            _cache.Remove(mb.GameId);
        }

        public async Task Terminate(int gameId)
        {
            var gameData = await _cache.GetData(gameId);

            await _gamesRepository.TerminateMinesBoom(gameId, gameData.UserSelections);

            _cache.Remove(gameId);
        }
    }
}
