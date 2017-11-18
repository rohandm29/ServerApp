using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerResponse
    {
        public int Id { get; }

        public CaptchaErrorCodes ErrorCode { get; }

        public List<string> Errors { get; }

        public CaptchaAnswerResponse(int id, CaptchaErrorCodes errorCode, List<string> errors)
        {
            Id = id;
            ErrorCode = errorCode;
            Errors = errors;
        }
    }
}
