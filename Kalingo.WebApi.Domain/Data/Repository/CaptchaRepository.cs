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
        private readonly AddCaptchaCommand _addCaptcha;
        private readonly SubmitCaptchaCommand _submitCaptchaCommand;

        public CaptchaRepository(GetCaptchaQuery getCaptchaQuery, AddCaptchaCommand addCaptcha, SubmitCaptchaCommand submitCaptcha)
        {
            _getCaptchaQuery = getCaptchaQuery;
            _addCaptcha = addCaptcha;
            _submitCaptchaCommand = submitCaptcha;
        }

        public async Task<CaptchaResponse> GetCaptcha(int id, CaptchaRequest captchaArgs)
        {
            return await _getCaptchaQuery.Execute(id, captchaArgs);
        }

        public async Task<bool> SubmitCaptcha(CaptchaAnswerRequest captchaAnswer)
        {
            return await _submitCaptchaCommand.Execute(captchaAnswer);
        }

        public async Task AddCaptcha(int id, CaptchaRequest captchaArgs)
        {
            await _addCaptcha.Execute(id, captchaArgs);
        }
    }
}