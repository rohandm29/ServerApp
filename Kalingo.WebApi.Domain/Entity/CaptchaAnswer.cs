namespace Kalingo.WebApi.Domain.Entity
{
    public class CaptchaAnswer
    {
        public int CaptchaAnswerId { get; }

        public int CaptchaAnswerGameId { get; }

        public bool IsCorrect { get; }

        public CaptchaAnswer(int captchaAnswerId, int captchaAnswerGameId, bool isCorrect)
        {
            CaptchaAnswerId = captchaAnswerId;
            CaptchaAnswerGameId = captchaAnswerGameId;
            IsCorrect = isCorrect;
        }
    }
}
