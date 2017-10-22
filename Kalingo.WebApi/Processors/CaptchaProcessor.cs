using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.Repository;

namespace Kalingo.WebApi.Processors
{
    public class CaptchaProcessor
    {
        private readonly CaptchaRepository _captchaRepository;

        public CaptchaProcessor(CaptchaRepository captchaRepository)
        {
            _captchaRepository = captchaRepository;
        }

        public Task<CaptchaResponse> GetCaptcha(CaptchaArgs captchaArgs)
        {
            return _captchaRepository.GetCaptcha(captchaArgs);
        }

        public Task<CaptchaResult> SubmitCaptcha(CaptchaAnswer captchaAnswer)
        {
            return _captchaRepository.SubmitCaptcha(captchaAnswer);
        }
    }
}