using System.Collections.Generic;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesboomSettings
    {
        public IEnumerable<Settings> Setting;

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
}
