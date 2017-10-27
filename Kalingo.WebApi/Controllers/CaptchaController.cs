using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("captcha")]
    public class CaptchaController : ApiController
    {
        private readonly CaptchaProcessor _processor;

        public CaptchaController(CaptchaProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Gets the captcha image.
        /// </summary>
        /// <param name="captchaArgs"></param>
        /// <returns></returns>
        [Route("Get")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCaptcha(CaptchaArgs captchaArgs)
        {
            var image = await _processor.GetCaptcha(captchaArgs);

            return Ok(image);
        }

       
        /// <summary>
        /// Update the user details.
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPatch]
        public async Task<IHttpActionResult> SubmitCaptcha(CaptchaAnswer captchaAnswer)
        {
            var result = await _processor.SubmitCaptcha(captchaAnswer);

            return Ok(result);
        }
    }
}
