namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class MinesboomSelectionResponse : GameResult
    {
        private new const int GameId = 1;

        public MinesboomSelectionResponse(int gameId, bool selectionCorrect, string userSelection) 
            : base(gameId, GameId)
        {
            SelectionCorrect = selectionCorrect;
            UserSelection = userSelection;
        }

        public bool SelectionCorrect { get; set; }

        /// <summary>
        /// Number of valid values game has.
        /// </summary>
        public int GiftsHidden { get; set; }

        /// <summary>
        /// Number of chances user has.
        /// </summary>
        public int TotalChances { get; set; }

        /// <summary>
        /// The value that was generated as random.
        /// </summary>
        public string UserSelection { get; set; }

        public int CoinsWon { get; set; }

        public int CoinType { get; set; }

        public string RandomSequence { get; set; }
    }
}
