using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Configuration;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.WebApi.Domain.Exceptions;

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

        public async Task<int> NewMinesBoom(NewMinesboomRequest minesboomRequest)
        {
            var randomSequence = _randomProvider.CreateRandomSequenceForMinesBoom();

            var gameId = await _gamesRepository.CreateMinesBoom(minesboomRequest, RandomProvider.GetDelimatedSequence(randomSequence));

            if (gameId == -1)
            {
                throw new PlayLimitExceedException("Play limit exceeded");
            }

            var gameData = new MinesBoomGameState(minesboomRequest.UserId, randomSequence, _mbGameSettings.TotalGifts, _mbGameSettings.TotalChances);

            await _minesBoomCache.Add(gameId, gameData);

            return gameId;
        }
    }
}
