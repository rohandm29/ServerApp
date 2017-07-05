namespace Kalingo.Games.Contract.Entity.Ladders
{
    public class LaddersGameArgs : GameArgs
    {
        private const int LaddersGameId = 2; 

        public LaddersGameArgs(int gameId,  int userId, int selectedOption)
            : base(gameId, userId, LaddersGameId)
        {
            SelectedOption = selectedOption;
            GameId = gameId;
            UserId = userId;
        }

        public int SelectedOption { get; set; }
    }
}