using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerResponse
    {
        private int Id { get; }

        private CaptchaErrorCodes ErrorCode { get; }

        private List<string> Errors { get; }

        public CaptchaAnswerResponse(int id, CaptchaErrorCodes errorCode, List<string> errors)
        {
            Id = id;
            ErrorCode = errorCode;
            Errors = errors;
        }
    }
}
