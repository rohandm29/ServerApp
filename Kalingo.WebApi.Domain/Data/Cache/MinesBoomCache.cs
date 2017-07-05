using System;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Cache
{
    public class MinesBoomCache
    {
        private const string MinesBoomCacheName = "MinesBoomCacheName";
        private readonly CacheItemPolicy _cacheItemPolicy;
        private readonly MemoryCache _cache;

        public MinesBoomCache()
        {
            _cacheItemPolicy = new CacheItemPolicy {AbsoluteExpiration = DateTime.UtcNow.AddMinutes(10)};
            _cache = new MemoryCache(MinesBoomCacheName);
        }

        /// <summary>
        /// Adds the sequence of a game to the cache
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="mbGameState"></param>
        public async Task Add(int gameId, MinesBoomGameState mbGameState)
        {
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
