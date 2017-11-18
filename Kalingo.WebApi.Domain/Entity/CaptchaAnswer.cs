namespace Kalingo.WebApi.Domain.Entity
{
    public class CaptchaAnswer
    {
        public int CaptchaAnswerId { get; }

        public int CaptchaAnswerGameId { get; }

        public bool FirstOrDefault { get; }

        public CaptchaAnswer(int captchaAnswerId, int captchaAnswerGameId, bool firstOrDefault)
        {
            CaptchaAnswerId = captchaAnswerId;
            CaptchaAnswerGameId = captchaAnswerGameId;
            FirstOrDefault = firstOrDefault;
        }
    }
}
