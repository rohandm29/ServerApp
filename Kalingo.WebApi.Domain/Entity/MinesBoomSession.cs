using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomSession
    {
        private MinesBoomSession(MinesBoomGameResult gameResult, MinesBoomGameState gameState)
        {
            GameId = gameResult.GameId;
            GameResult = gameResult;
            GameState = gameState;
        }

        public static MinesBoomSession Create(MinesBoomGameResult mbGameResult, MinesBoomGameState mbGameState)
        {
            var minesBoom = new MinesBoomSession(mbGameResult, mbGameState);

            return minesBoom;
        }

        public static MinesBoomSession CreateNotFound(MinesBoomGameResult mbGameResult, MinesBoomGameState mbGameState)
        {
            return new MinesBoomSession(mbGameResult, mbGameState);
        }

        public int GameId { get; }

        public MinesBoomGameResult GameResult { get; }

        public MinesBoomGameState GameState { get; }
    }
}
