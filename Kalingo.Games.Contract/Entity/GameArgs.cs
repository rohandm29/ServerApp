namespace Kalingo.Games.Contract.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class GameArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <param name="gameTypeId"></param>
        public GameArgs(int gameId, string userId, int gameTypeId)
        {
            GameId = gameId;
            UserId = userId;
            GameTypeId = gameTypeId;
        }

        public int GameId { get; protected set; }

        public string UserId { get; protected set; }

        public int GameTypeId { get; }
    }
}