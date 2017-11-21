using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Cleaner;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Cache
{
    public class MinesBoomCache
    {
        private const string MinesBoomCacheName = "MinesBoomCacheName";
        private CacheItemPolicy _cacheItemPolicy;
        private readonly MemoryCache _cache;

        private readonly GamesRepository _gamesRepository;

        public MinesBoomCache(GamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;

            _cache = new MemoryCache(MinesBoomCacheName);
        }

        private async void RemovedCallback(CacheEntryRemovedArguments arguments)
        {
            if (arguments.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                var item = (MinesBoomGameState) arguments.CacheItem.Value;

                await _gamesRepository.TerminateMinesBoom(item.UserId, int.Parse(arguments.CacheItem.Key),
                    item.RandomSequence, item.UserSelections, true);
            }
        }

        /// <summary>
        /// Adds the sequence of a game to the cache
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="mbGameState"></param>
        public async Task Add(int gameId, MinesBoomGameState mbGameState)
        {
            _cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.UtcNow.AddMinutes(1),
                RemovedCallback = RemovedCallback
            };

            await Task.Run(()=> _cache.Add(new CacheItem(gameId.ToString(), mbGameState), _cacheItemPolicy));
        }

        /// <summary>
        /// Updates the cacheItem
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="mbGameState"></param>
        public void Update(int gameId, MinesBoomGameState mbGameState)
        {
            _cache.Set(gameId.ToString(), mbGameState, _cacheItemPolicy);
        }

        /// <summary>
        /// Checks if the selection is present
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public bool IsAlive(int gameId)
        {
            return _cache.Contains(gameId.ToString());
        }

        /// <summary>
        /// Checks if the selection is correct
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<MinesBoomGameState> GetData(int gameId)
        {
            var mbGameState = (MinesBoomGameState) _cache.Get(gameId.ToString());

            return mbGameState;
        }

        public void Remove(int gameId)
        {
             _cache.Remove(gameId.ToString());
        }
    }
}
