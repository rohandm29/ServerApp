namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerRequest
    {
        public int CaptchaId { get; }

        public string Answer { get; }

        public int GameId { get; }

        public CaptchaAnswerRequest(int captchaId, string answer, int gameId)
        {
            CaptchaId = captchaId;
            Answer = answer;
            GameId = gameId;
        }
    }
}
