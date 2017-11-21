using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;
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

        public async Task<CaptchaResponse> GetCaptcha(CaptchaRequest captchaArgs)
        {
            try
            {
                var id = _randomGenerator.GetNumber(new NumberSet(1, 4));

                return await _captchaRepository.GetCaptcha(id, captchaArgs);
            }
            catch (Exception)
            {
               return new CaptchaResponse(0, string.Empty);
            }
        }

        public async Task<CaptchaAnswerResponse> SubmitCaptcha(CaptchaAnswerRequest captchaAnswerRequest)
        {
            try
            {
                var isCorrect = await _captchaRepository.SubmitCaptcha(captchaAnswerRequest);

                return isCorrect
                    ? new CaptchaAnswerResponse(captchaAnswerRequest.CaptchaId, CaptchaCodes.Valid)
                    : new CaptchaAnswerResponse(captchaAnswerRequest.CaptchaId, CaptchaCodes.Invalid,
                        new List<string> {"Does not match"});
            }
            catch (Exception)
            {
                return new CaptchaAnswerResponse(captchaAnswerRequest.CaptchaId, CaptchaCodes.NotFound,
                    new List<string> { "Not Found" });
            }
        }
    }
}