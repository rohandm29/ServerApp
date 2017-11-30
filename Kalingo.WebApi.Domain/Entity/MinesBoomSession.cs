using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomSession
    {
        private MinesBoomSession(string userId, MinesboomSelectionResponse gameResult, MinesBoomGameState gameState)
        {
            UserId = userId;
            GameId = gameResult.GameId;
            GameResult = gameResult;
            GameState = gameState;
        }

        public static MinesBoomSession Create(string userId, MinesboomSelectionResponse mbGameResult, MinesBoomGameState mbGameState)
        {
            var minesBoom = new MinesBoomSession(userId, mbGameResult, mbGameState);

            return minesBoom;
        }

        public static MinesBoomSession CreateNotFound(string userId, MinesboomSelectionResponse mbGameResult, MinesBoomGameState mbGameState)
        {
            return new MinesBoomSession(userId, mbGameResult, mbGameState);
        }

        public string UserId { get; }

        public int GameId { get; }

        public MinesboomSelectionResponse GameResult { get; }

        public MinesBoomGameState GameState { get; }
    }
}
