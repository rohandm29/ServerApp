using System.Collections.Generic;
using Kalingo.Games.Contract.Entity.Captcha;

namespace Kalingo.WebApi.Domain.Data.Cache
{
    public class CaptchaDictionary
    {
        private static readonly Dictionary<int, CaptchaResponse> CaptchaCache = new Dictionary<int, CaptchaResponse>();

        public static CaptchaResponse Get(int captchaId)
        {
            if (!CaptchaCache.ContainsKey(captchaId)) return null;

            CaptchaResponse response;
            CaptchaCache.TryGetValue(captchaId, out response);
            return response;
        }

        public static void Add(CaptchaResponse response)
        {
            if (!CaptchaCache.ContainsKey(response.CaptchaId))
            {
                CaptchaCache.Add(response.CaptchaId, response);
            }
        }
    }
}
