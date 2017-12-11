using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.WebApi.Domain;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;
using Microsoft.Azure;

namespace Kalingo.WebApi.Processors
{
    public class CaptchaProcessor
    {
        private readonly CaptchaRepository _captchaRepository;
        private readonly RandomGenerator _randomGenerator;
        private readonly int _voucherMaxId;

        public CaptchaProcessor(CaptchaRepository captchaRepository, RandomGenerator randomGenerator)
        {
            _captchaRepository = captchaRepository;
            _randomGenerator = randomGenerator;
            _voucherMaxId = int.Parse(CloudConfigurationManager.GetSetting("VoucherMaxId"));
        }

        public async Task<CaptchaResponse> GetCaptcha(CaptchaRequest captchaArgs)
        {
            try
            {
                var id = _randomGenerator.GetNumber(new NumberSet(1, _voucherMaxId));

                return await _captchaRepository.GetCaptcha(id, captchaArgs);
            }
            catch (Exception e)
            {
                Log.Error(e);
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
            catch (Exception e)
            {
                Log.Error(e);

                return new CaptchaAnswerResponse(captchaAnswerRequest.CaptchaId, CaptchaCodes.NotFound,
                    new List<string> { e.Message + " - Not Found" });
            }
        }
    }
}