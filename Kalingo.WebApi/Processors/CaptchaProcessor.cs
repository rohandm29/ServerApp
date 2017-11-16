using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Processors
{
    public class CaptchaProcessor
    {
        private readonly CaptchaRepository _captchaRepository;
        private readonly RandomGenerator _randomGenerator;

        public CaptchaProcessor(CaptchaRepository captchaRepository, RandomGenerator randomGenerator)
        {
            _captchaRepository = captchaRepository;
            _randomGenerator = randomGenerator;
        }

        public Task<CaptchaResponse> GetCaptcha(CaptchaRequest captchaArgs)
        {
            var id = _randomGenerator.GetNumber(new NumberSet(1, 4));

            return _captchaRepository.GetCaptcha(id, captchaArgs);
        }

        public Task<CaptchaAnswerResponse> SubmitCaptcha(CaptchaAnswerRequest captchaAnswer)
        {
            return _captchaRepository.SubmitCaptcha(captchaAnswer);
        }
    }
}