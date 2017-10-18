using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomSession
    {
        private MinesBoomSession(int userId, MinesBoomGameResult gameResult, MinesBoomGameState gameState)
        {
            UserId = userId;
            GameId = gameResult.GameId;
            GameResult = gameResult;
            GameState = gameState;
        }

        public static MinesBoomSession Create(int userId, MinesBoomGameResult mbGameResult, MinesBoomGameState mbGameState)
        {
            var minesBoom = new MinesBoomSession(userId, mbGameResult, mbGameState);

            return minesBoom;
        }

        public static MinesBoomSession CreateNotFound(int userId, MinesBoomGameResult mbGameResult, MinesBoomGameState mbGameState)
        {
            return new MinesBoomSession(userId, mbGameResult, mbGameState);
        }

        public int UserId { get; }

        public int GameId { get; }

        public MinesBoomGameResult GameResult { get; }

        public MinesBoomGameState GameState { get; }
    }
}
