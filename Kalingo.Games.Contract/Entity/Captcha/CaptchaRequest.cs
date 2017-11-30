namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaRequest
    {
        public string UserId { get; }

        public int GameId { get; }

        public CaptchaRequest(string userId, int gameId)
        {
            UserId = userId;
            GameId = gameId;
        }
    }
}
