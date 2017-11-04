namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class MinesBoomGameResult : GameResult
    {
        private new const int GameId = 2;

        public MinesBoomGameResult(int gameId, bool selectionCorrect, string userSelection, string comment) 
            : base(gameId, GameId)
        {
            SelectionCorrect = selectionCorrect;
            UserSelection = userSelection;
            Comment = comment;
        }

        public bool SelectionCorrect { get; set; }

        /// <summary>
        /// Number of valid values game has.
        /// </summary>
        public int TotalGifts { get; set; }

        /// <summary>
        /// Number of chances user has.
        /// </summary>
        public int TotalChances { get; set; }

        /// <summary>
        /// The value that was generated as random.
        /// </summary>
        public string UserSelection { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public string Comment { get; set; }

        public string RandomSequence { get; set; }
    }
}
