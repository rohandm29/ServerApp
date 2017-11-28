using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Configuration;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class MinesBoomCreationEngine
    {
        private readonly RandomProvider _randomProvider;
        private readonly MinesBoomCache _minesBoomCache;
        private readonly GamesRepository _gamesRepository;
        private readonly MinesBoomGameSettings _mbGameSettings;

        public MinesBoomCreationEngine(RandomProvider randomProvider, MinesBoomCache minesBoomCache, GamesRepository gamesRepository, MinesBoomGameSettings mbGameSettings)
        {
            _randomProvider = randomProvider;
            _minesBoomCache = minesBoomCache;
            _gamesRepository = gamesRepository;
            _mbGameSettings = mbGameSettings;
        }

        public async Task<int> NewMinesBoom(int userId)
        {
            var randomSequence = _randomProvider.CreateRandomSequenceForMinesBoom();

            var gameId = await _gamesRepository.CreateMinesBoom(userId, RandomProvider.GetDelimatedSequence(randomSequence));

            var gameData = new MinesBoomGameState(userId, randomSequence, _mbGameSettings.TotalGifts, _mbGameSettings.TotalChances);

            await _minesBoomCache.Add(gameId, gameData);

            return gameId;
        }
    }
}
