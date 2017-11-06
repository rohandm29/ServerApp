using System.Collections.Generic;
using Kalingo.WebApi.Domain.Data.Repository;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesboomSettings
    {
        private readonly GamesRepository _gamesRepository;

        public MinesboomSettings(GamesRepository _gamesRepository)
        {
            this._gamesRepository = _gamesRepository;
            FetchSettings();
        }

        public IEnumerable<Settings> Setting;
        
        private void FetchSettings()
        {
            var settings = _gamesRepository.GetMinesboomSettings();

            Setting = settings;
        }
    }

     public class Settings
        {
            public int CoinTypeId { get; }

            public int MinesCount { get; }

            public int CoinCount { get; }

            public int Chances { get; }

            public Settings(int coinTypeId, int minesCount, int coinCount, int chances)
            {
                CoinTypeId = coinTypeId;
                MinesCount = minesCount;
                CoinCount = coinCount;
                Chances = chances;
            }
        }
}
