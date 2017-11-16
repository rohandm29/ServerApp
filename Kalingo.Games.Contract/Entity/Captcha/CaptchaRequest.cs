namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaRequest
    {
        public int UserId { get; }

        public int GameId { get; }

        public CaptchaRequest(int userId, int gameId)
        {
            UserId = userId;
            GameId = gameId;
        }
    }
}
