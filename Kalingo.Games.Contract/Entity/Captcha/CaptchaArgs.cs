namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaArgs
    {
        public int UserId { get; }

        public int GameId { get; }

        public CaptchaArgs(int userId, int gameId)
        {
            UserId = userId;
            GameId = gameId;
        }
    }
}
