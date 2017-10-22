using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class CaptchaRepository
    {
        private readonly GetCaptchaQuery _getCaptchaQuery;
       
        public CaptchaRepository(GetCaptchaQuery getCaptchaQuery)
        {
            _getCaptchaQuery = getCaptchaQuery;
        }

        public async Task<CaptchaResponse> GetCaptcha(CaptchaArgs captchaArgs)
        {
            return await _getCaptchaQuery.Execute(captchaArgs);
        }
    }
}