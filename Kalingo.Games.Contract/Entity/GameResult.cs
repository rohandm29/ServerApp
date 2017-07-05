namespace Kalingo.Games.Contract.Entity
{
    /// <summary>
    /// The win of random generation
    /// </summary>
    public class GameResult
    {
        public GameResult(int gameId, int gameTypeId)
        {
            GameId = gameId;
            GameTypeId = gameTypeId;
        }

        /// <summary>
        /// Identifier of the game in context
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// The type of game
        /// </summary>
        public int  GameTypeId { get; set; }
        
        /// <summary>
        /// Indicates if game is won or lost
        /// </summary>
        public bool HasWon { get; set; }
    }
}