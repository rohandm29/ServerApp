using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class NewMinesboomResponse
    {
        public int GameId { get; }

        public IEnumerable<Settings> Settings { get; }

        public NewMinesboomResponse(int gameId, IEnumerable<Settings> settings)
        {
            GameId = gameId;
            Settings = settings;
        }
    }
}
