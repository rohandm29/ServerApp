namespace Kalingo.Games.Contract.Entity.Ladders
{
    public class LaddersGameRequest : GameArgs
    {
        private const int LaddersGameId = 2; 

        public LaddersGameRequest(int gameId,  string userId, int selectedOption)
            : base(gameId, userId, LaddersGameId)
        {
            SelectedOption = selectedOption;
            GameId = gameId;
            UserId = userId;
        }

        public int SelectedOption { get; set; }
    }
}