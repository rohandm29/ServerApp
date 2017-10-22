namespace Kalingo.Games.Contract.Entity
{
    public class CaptchaArgs
    {
        public string UserId { get; }

        public string GameId { get; }

        public CaptchaArgs(string userId, string gameId)
        {
            UserId = userId;
            GameId = gameId;
        }
    }
}
