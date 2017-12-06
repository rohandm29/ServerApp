namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class NewMinesboomRequest
    {
        public int UserId { get; }

        public string Reward { get; }

        public bool PlayAgain { get; set; }

        public NewMinesboomRequest(int userId, string reward, bool playAgain)
        {
            UserId = userId;
            Reward = reward;
            PlayAgain = playAgain;
        }
    }
}
