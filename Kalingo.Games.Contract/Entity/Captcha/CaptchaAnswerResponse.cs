using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerResponse
    {
        public int Id { get; }

        public CaptchaCodes Code { get; }

        public List<string> Errors { get; }

        public CaptchaAnswerResponse(int id, CaptchaCodes code, List<string> errors = null)
        {
            Id = id;
            Code = code;
            Errors = errors;
        }
    }
}
