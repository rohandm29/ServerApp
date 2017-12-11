using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Caching;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Microsoft.Azure;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesboomSettings
    {
        private readonly MemoryCache _settingCache;
        private CacheItemPolicy _cacheItemPolicy;
        private readonly int _timeInMins;

        private readonly GamesRepository _gamesRepository;
        private IEnumerable<Settings> _settings;

        public MinesboomSettings(GamesRepository _gamesRepository)
        {
            this._gamesRepository = _gamesRepository;

            _timeInMins = int.Parse(CloudConfigurationManager.GetSetting("SettingsCacheExpirationMin"));
            _settingCache = new MemoryCache("Settings");
        }

        public IEnumerable<Settings> Setting
        {
            get
            {
                if(_settingCache.Contains("settings"))
                {
                    _settings = (IEnumerable<Settings>) _settingCache.Get("settings");
              
                    return _settings;
                }

                var settings = FetchSettings();
                _cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow.AddMinutes(_timeInMins) };
                _settingCache.Add("settings", settings, _cacheItemPolicy);

                return settings;
            }
        }
        

        private IEnumerable<Settings> FetchSettings()
        {
            var settings = _gamesRepository.GetMinesboomSettings();

            return settings;
        }
    }
}
