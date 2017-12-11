namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaRequest
    {
        public int CaptchId { get; }

        public int GameId { get; }

        public CaptchaRequest(int captchId, int gameId)
        {
            CaptchId = captchId;
            GameId = gameId;
        }
    }
}
