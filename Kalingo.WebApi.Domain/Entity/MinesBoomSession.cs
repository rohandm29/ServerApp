using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomSession
    {
        private MinesBoomSession(int userId, MinesboomSelectionResponse gameResult, MinesBoomGameState gameState)
        {
            UserId = userId;
            GameId = gameResult.GameId;
            GameResult = gameResult;
            GameState = gameState;
        }

        public static MinesBoomSession Create(int userId, MinesboomSelectionResponse mbGameResult, MinesBoomGameState mbGameState)
        {
            var minesBoom = new MinesBoomSession(userId, mbGameResult, mbGameState);

            return minesBoom;
        }

        public static MinesBoomSession CreateNotFound(int userId, MinesboomSelectionResponse mbGameResult, MinesBoomGameState mbGameState)
        {
            return new MinesBoomSession(userId, mbGameResult, mbGameState);
        }

        public int UserId { get; }

        public int GameId { get; }

        public MinesboomSelectionResponse GameResult { get; }

        public MinesBoomGameState GameState { get; }
    }
}
