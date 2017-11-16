using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class CaptchaRepository
    {
        private readonly GetCaptchaQuery _getCaptchaQuery;
        private readonly SubmitCaptchaCommand _submitCaptchaCommand;

        public CaptchaRepository(GetCaptchaQuery getCaptchaQuery, SubmitCaptchaCommand submitCaptcha)
        {
            _getCaptchaQuery = getCaptchaQuery;
            _submitCaptchaCommand = submitCaptcha;
        }

        public async Task<CaptchaResponse> GetCaptcha(int id, CaptchaRequest captchaArgs)
        {
            return await _getCaptchaQuery.Execute(id, captchaArgs);
        }

        public async Task<CaptchaAnswerResponse> SubmitCaptcha(CaptchaAnswerRequest captchaAnswer)
        {
            return await _submitCaptchaCommand.Execute(captchaAnswer);
        }
    }
}